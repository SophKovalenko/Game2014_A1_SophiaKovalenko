//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 1
//  Run Princess, Run! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: October 16th, 2022
//  Last modified: October 20th, 2022
//////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Properties")]
    public float speed = 6.0f;
    public Boundary boundary;
    public float horizontalPosition = -9.5f;

    [Header("Bullet Properties")]
    public Transform bulletSpawnPoint;
    private float fireRate = 1.2f;

    private Camera camera;
    private BulletManager bulletManager;

    private AudioSource playerAudio;
    public AudioClip firePlayerBullet;
    public AudioClip playerHurt;
    public AudioClip pickupGem;
    public AudioClip pickupPowerup;
    public AudioClip restoreLife;
    public AudioClip crashIntoHazard;

    public int invincibilityTimer = 0;
    public int increasedSpeedTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
        playerAudio = GetComponent<AudioSource>();

        transform.position = new Vector2(horizontalPosition, 0.0f);
        camera = Camera.main;

       InvokeRepeating("FireBullets", 0.1f, fireRate);

    }

    // Update is called once per frame
    void Update()
    {
        GetUserInput();
        Move();

        if (GameManager.Instance.IsPlayerInvincible == true)
        {
            invincibilityTimer++;

            if (invincibilityTimer >= 1)
            {
                GameManager.Instance.IsPlayerInvincible = false;
                invincibilityTimer = 0;
            }
        }

        if (GameManager.Instance.HasPlayerSpedUp == true)
        {
            increasedSpeedTimer++;
        }
    }

    void GetUserInput()
    {
        foreach (Touch touch in Input.touches)
        {
            var destination = camera.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * speed);
        }
    }

    void Move()
    {
        float clampedYPosition = Mathf.Clamp(transform.position.y, boundary.minBoundary, boundary.maxBoundary);
        transform.position = new Vector2(horizontalPosition, clampedYPosition);
    }

    void FireBullets()
    {
        bulletManager.GetBullet(bulletSpawnPoint.position, BulletType.PLAYER);
        playerAudio.PlayOneShot(firePlayerBullet, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BlueGem"))
        {
            Debug.Log("Blue Gem Collected!");

            //Add 50 points to score
            ScoreKeeper.totalScore += 50;

            playerAudio.PlayOneShot(pickupGem, 1.0f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("GreenGem"))
        {
            Debug.Log("Green Gem Collected!");

            //Add 25 points to score
            ScoreKeeper.totalScore += 25;

            playerAudio.PlayOneShot(pickupGem, 1.0f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("OrangeGem"))
        {
            Debug.Log("Orange Gem Collected!");

            //Add 10 points to score
            ScoreKeeper.totalScore += 10;

            playerAudio.PlayOneShot(pickupGem, 1.0f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("ExtraLife"))
        {
            if (GameManager.Instance.Lives <= 3)
            { GameManager.Instance.Lives += 1;
                Debug.Log("Extra Life Collected!");

                playerAudio.PlayOneShot(restoreLife, 1.0f); 
            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Hazard"))
        {
            GameManager.Instance.Lives -= 1;
            Debug.Log("You lose a life!");

            playerAudio.PlayOneShot(crashIntoHazard, 1.0f);
            Destroy(other.gameObject);

            if (GameManager.Instance.Lives <= 0)
            {
               GameManager.Instance.IsPlayerDead = true;
            }
        }

        if (other.gameObject.CompareTag("Horse"))
        {
            GameManager.Instance.HasPlayerSpedUp = true;
            Debug.Log("You gain speed!");
            playerAudio.PlayOneShot(pickupPowerup, 1.0f);

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Star"))
        {
            GameManager.Instance.IsPlayerInvincible = true;
            Debug.Log("You are invincible for 10 seconds!");
            playerAudio.PlayOneShot(pickupPowerup, 1.0f);

            if (invincibilityTimer >= 1.0f)
            {
                GameManager.Instance.IsPlayerInvincible = false;
                invincibilityTimer = 0;
            }

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet"))
        {
            GameManager.Instance.Lives -= 1;
            playerAudio.PlayOneShot(playerHurt, 1.0f);

            if (GameManager.Instance.Lives <= 0)
            {
                GameManager.Instance.IsPlayerDead = true;
            }

        }
    }
}
