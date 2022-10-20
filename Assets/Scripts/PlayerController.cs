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
    public bool usingMobileInput = false;

    [Header("Bullet Properties")]
    public Transform bulletSpawnPoint;
    [Range(0.1f, 1.0f)]
    public float fireRate = 0.2f;


    private Camera camera;
    private BulletManager bulletManager;
    //private ScoreController scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        //scoreManager = FindObjectOfType<ScoreController>();
        bulletManager = FindObjectOfType<BulletManager>();

        transform.position = new Vector2(horizontalPosition, 0.0f);
        camera = Camera.main;

       InvokeRepeating("FireBullets", 0.1f, fireRate);

    }

    // Update is called once per frame
    void Update()
    {
        GetMobileInput();
        Move();

        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    scoreManager.AddPoints(10);
        //}
    }

    void GetMobileInput()
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
}
