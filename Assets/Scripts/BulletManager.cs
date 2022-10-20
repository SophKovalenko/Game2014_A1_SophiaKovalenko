using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    [Header("Player Bullets")]
    [Range(10, 200)]
    public int playerBulletNumber = 20;
    public int playerBulletCount;
    public int activePlayerBullets = 0;

    [Header("Enemy Bullets")]
    [Range(10, 200)]
    public int enemyBulletNumber = 30;
    public int enemyBulletCount;
    public int activeEnemyBullets = 0;

    private Queue<GameObject> PlayerBulletPool;
    private Queue<GameObject> EnemyBulletPool;
    private BulletFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        PlayerBulletPool = new Queue<GameObject>(); // creates an empty Queue
        EnemyBulletPool = new Queue<GameObject>(); // creates an empty Queue
        factory = GameObject.FindObjectOfType<BulletFactory>();
        BuildBulletPools();
    }

    void BuildBulletPools()
    {
        for (int i = 0; i < playerBulletNumber; i++)
        {
            PlayerBulletPool.Enqueue(factory.CreateBullet(BulletType.PLAYER));
        }

        for (int i = 0; i < enemyBulletNumber; i++)
        {
            EnemyBulletPool.Enqueue(factory.CreateBullet(BulletType.ENEMY));
        }
    }


    public GameObject GetBullet(Vector2 position, BulletType type)
    {
        GameObject bullet = null;

        switch (type)
        {
            case BulletType.PLAYER:
                {
                    if (PlayerBulletPool.Count < 1)
                    {
                        PlayerBulletPool.Enqueue(factory.CreateBullet(BulletType.PLAYER));
                    }
                    bullet = PlayerBulletPool.Dequeue();
                    // stats
                    activePlayerBullets++;
                    playerBulletCount = PlayerBulletPool.Count;
                }

                break;
            case BulletType.ENEMY:
                {
                    if (EnemyBulletPool.Count < 1)
                    {
                        EnemyBulletPool.Enqueue(factory.CreateBullet(BulletType.ENEMY));
                    }
                    bullet = EnemyBulletPool.Dequeue();
                    // stats
                    activeEnemyBullets++;
                    enemyBulletCount = EnemyBulletPool.Count;
                }

                break;
        }

        bullet.SetActive(true);
        bullet.transform.position = position;

        return bullet;
    }

    public void ReturnBullet(GameObject bullet, BulletType type)
    {
        bullet.SetActive(false);

        switch (type)
        {
            case BulletType.PLAYER:

                PlayerBulletPool.Enqueue(bullet);
                // stats
                activePlayerBullets--;
                playerBulletCount = PlayerBulletPool.Count;

                break;
            case BulletType.ENEMY:
                EnemyBulletPool.Enqueue(bullet);
                // stats
                activeEnemyBullets--;
                enemyBulletCount = EnemyBulletPool.Count;
                break;
        }
    }

}

