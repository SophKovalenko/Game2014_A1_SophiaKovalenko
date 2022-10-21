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

[System.Serializable]
public struct ScreenBounds
{
    public Boundary horizontal;
    public Boundary vertical;
}

public class BulletBehaviour : MonoBehaviour
{
    [Header("Bullet Properties")]
    public BulletDirection bulletDirection;
    public float speed;
    public ScreenBounds bounds;
    private Vector3 velocity;
    public BulletManager bulletManager;
    public BulletType bulletType;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();

        //SetDirection((bulletType == BulletType.PLAYER) ? BulletDirection.UP : BulletDirection.DOWN);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    void Move()
    {
        transform.position += velocity * Time.deltaTime;
    }

    void CheckBounds()
    {
        if ((transform.position.x > bounds.horizontal.maxBoundary) ||
            (transform.position.x < bounds.horizontal.minBoundary) ||
            (transform.position.y > bounds.vertical.maxBoundary) ||
            (transform.position.y < bounds.vertical.minBoundary))
        {
            // return the bullet to the pool
            bulletManager.ReturnBullet(this.gameObject, bulletType);
        }
    }

    public void SetDirection(BulletDirection direction)
    {
        switch (direction)
        {
            case BulletDirection.Up:
                velocity = Vector3.up * speed;
                break;
            case BulletDirection.Right:
                velocity = Vector3.right * speed;
                break;
            case BulletDirection.Down:
                velocity = Vector3.down * speed;
                break;
            case BulletDirection.Left:
                velocity = Vector3.left * speed;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (bulletType == BulletType.PLAYER && other.gameObject.CompareTag("Enemy"))
        {
            bulletManager.ReturnBullet(this.gameObject, bulletType);
        }

        if (bulletType == BulletType.ENEMY && other.gameObject.CompareTag("Player"))
        {
            bulletManager.ReturnBullet(this.gameObject, bulletType);
            GameManager.Instance.Lives -= 1;
        }

    }
}