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
        if ((bulletType == BulletType.PLAYER) ||
            (bulletType == BulletType.ENEMY && other.gameObject.CompareTag("Player")))
        {
            bulletManager.ReturnBullet(this.gameObject, bulletType);
        }

    }
}