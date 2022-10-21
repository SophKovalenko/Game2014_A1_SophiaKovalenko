//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 1
//  Run Princess, Run! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: October 20th, 2022
//  Last modified: October 20th, 2022
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

    [Header("Bullet Properties")]
    public Transform bulletSpawnPoint;
    private float fireRate = 2.0f;

    private SpriteRenderer spriteRenderer;
    private BulletManager bulletManager;

    public bool enemyCanShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bulletManager = FindObjectOfType<BulletManager>();
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
    }

    void Move()
    {
        var boundaryLength = verticalBoundary.maxBoundary - verticalBoundary.minBoundary;
        transform.position = new Vector3(transform.position.x - horizontalSpeed * Time.deltaTime, Mathf.PingPong(Time.time * verticalSpeed, boundaryLength) - verticalBoundary.maxBoundary, 0.0f);
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
        horizontalSpeed = Random.Range(0.5f, 2.0f);
        verticalSpeed = Random.Range(0.5f, 5.0f);
        transform.position = new Vector3(11.0f, RandomYPosition, 0.0f);
    }

    void FireBullets()
    {
        bulletManager.GetBullet(bulletSpawnPoint.position, BulletType.ENEMY);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ResetEnemy();
            GameManager.Instance.Lives -= 1;

            if (GameManager.Instance.Lives == 0)
            {
               // GameManager.Instance.IsPlayerDead = true;
            }
            //Crash sfx
        }

    }
}