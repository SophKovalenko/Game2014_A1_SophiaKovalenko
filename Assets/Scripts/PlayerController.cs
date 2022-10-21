//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 1
//  Run Princess, Run! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: October 16th, 2022
//  Last modified: October 16th, 2022
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
    private float fireRate = 1.0f;

    private Camera camera;
    private BulletManager bulletManager;

    public int invincibilityTimer = 0;
    public int increasedSpeedTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();

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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BlueGem"))
        {
            Debug.Log("Blue Gem Collected!");

            //Add 50 points to score
            GameManager.Instance.Score += 50;

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("GreenGem"))
        {
            Debug.Log("Green Gem Collected!");

            //Add 25 points to score
            GameManager.Instance.Score += 25;

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("OrangeGem"))
        {
            Debug.Log("Orange Gem Collected!");

            //Add 10 points to score
            GameManager.Instance.Score += 10;

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("ExtraLife"))
        {
            GameManager.Instance.Lives += 1;
            Debug.Log("Extra Life Collected!");

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Hazard"))
        {
            GameManager.Instance.Lives -= 1;
            Debug.Log("You lose a life!");

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Horse"))
        {
            GameManager.Instance.HasPlayerSpedUp = true;
            Debug.Log("You gain speed!");

            if (increasedSpeedTimer >= 100.0f)
            {
                GameManager.Instance.HasPlayerSpedUp = false;
                increasedSpeedTimer = 0;
            }

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Star"))
        {
            GameManager.Instance.IsPlayerInvincible = true;
            Debug.Log("You are invincible for 10 seconds!");

            if (invincibilityTimer >= 100.0f)
            {
                GameManager.Instance.IsPlayerInvincible = false;
                invincibilityTimer = 0;
            }

            Destroy(other.gameObject);
        }
    }
}
