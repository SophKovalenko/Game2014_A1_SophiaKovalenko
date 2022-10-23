//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 1
//  Run Princess, Run! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: October 20th, 2022
//  Last modified: October 23th, 2022
//  - this script controls the enemy movement after they are spawned and controls their reset on death
//  - created player reference so enemies can track the player in the scene
//  - enemies use MoveTo function to seek out the player and move towards their location in real time
//////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy Movement Properties")]
    public Boundary horizontalBoundary;
    public Boundary verticalBoundary;
    public Boundary screenBounds;
    private float horizontalSpeed;
    private float verticalSpeed;
  
    private GameObject playerReference;

    [Header("Bullet Properties")]
    public Transform bulletSpawnPoint;
    private float fireRate = 2.0f;
    public bool enemyCanShoot = false;

    private SpriteRenderer spriteRenderer;
    private BulletManager bulletManager;

    private AudioSource enemyAudio;
    public AudioClip fireEnemyBullet;
    public AudioClip enemyHurt;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bulletManager = FindObjectOfType<BulletManager>();
        enemyAudio = GetComponent<AudioSource>();

        //Used to find reference to the player in the scene
        playerReference = GameObject.FindGameObjectWithTag("Player");

        ResetEnemy();

        if (enemyCanShoot == true)
        {
            InvokeRepeating("FireBullets", 0.2f, fireRate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();

        if (GameManager.Instance.IsEnemyDestroyed == true)
        {
            ResetEnemy();
            enemyAudio.PlayOneShot(enemyHurt, 0.8f);
            GameManager.Instance.IsEnemyDestroyed = false;
        }
    }

    void Move()
    {
        //Seek the player's position while moving to the left at a random speed within the range
        transform.position = Vector2.MoveTowards(transform.position, playerReference.transform.position, Random.Range(2.0f, 5.0f) * Time.deltaTime);
    }

    public void CheckBounds()
    {
        if (transform.position.x < screenBounds.minBoundary)
        {
            ResetEnemy();
        }
    }

    public void ResetEnemy()
    {
        var RandomXPosition = Random.Range(horizontalBoundary.minBoundary, horizontalBoundary.maxBoundary);
        var RandomYPosition = Random.Range(verticalBoundary.minBoundary, verticalBoundary.maxBoundary);
        transform.position = new Vector3(11.0f, RandomYPosition, 0.0f);
    }

    void FireBullets()
    {
        bulletManager.GetBullet(bulletSpawnPoint.position, BulletType.ENEMY);
        enemyAudio.PlayOneShot(fireEnemyBullet, 1.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ResetEnemy();
        }

    }
}