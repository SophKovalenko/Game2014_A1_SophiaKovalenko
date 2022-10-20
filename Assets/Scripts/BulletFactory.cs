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
public class BulletFactory : MonoBehaviour
{
    // Bullet Prefab
    private GameObject bulletPrefab;

    // sprite textures
    private Sprite playerBulletSprite;
    private Sprite enemyBulletSprite;

    // Bullet Parent
    private Transform bulletParent;


    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        playerBulletSprite = Resources.Load<Sprite>("VisualAssets/Sprites/Projectile");
        enemyBulletSprite = Resources.Load<Sprite>("VisualAssets/Sprites/Arrow");
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
        bulletParent = GameObject.Find("Bullets").transform;
    }

    public GameObject CreateBullet(BulletType type)
    {
        var bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity, bulletParent);

        switch (type)
        {
            case BulletType.PLAYER:
                bullet.GetComponent<SpriteRenderer>().sprite = playerBulletSprite;
                bullet.GetComponent<BulletBehaviour>().bulletType = BulletType.PLAYER;
                bullet.GetComponent<BulletBehaviour>().SetDirection(BulletDirection.Right);

                break;
            case BulletType.ENEMY:
                bullet.GetComponent<SpriteRenderer>().sprite = enemyBulletSprite;
                bullet.GetComponent<BulletBehaviour>().bulletType = BulletType.ENEMY;
                bullet.GetComponent<BulletBehaviour>().SetDirection(BulletDirection.Left);
                break;
        }

        if (bullet != null)
        {
            bullet.SetActive(false);
        }

        return bullet;
    }


}
