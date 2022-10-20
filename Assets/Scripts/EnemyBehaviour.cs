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
    [Range(0.01f, 1.0f)]
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
        horizontalSpeed = Random.Range(1.0f, 3.0f);
        verticalSpeed = Random.Range(1.0f, 6.0f);
        transform.position = new Vector3(11.0f, RandomYPosition, 0.0f);
    }

    void FireBullets()
    {
        bulletManager.GetBullet(bulletSpawnPoint.position, BulletType.ENEMY);
    }
}