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

public class PickupSpawnManager : MonoBehaviour
{
    public GameObject[] spawnObjectsPrefabs;
    private float intervalOfSpawn = 3.0f;
    private float delayOfNextSpawn = 4.0f;

    public float horizonalLocation = 5.0f;
    public Boundary boundary;

    // Start is called before the first frame update
    void Start()
    {
        //When game begins, as long as player is alive, spawn new pickup objects
        if (GameManager.Instance.IsPlayerDead == false)
        {
            InvokeRepeating("SpawnPickupObjects", delayOfNextSpawn, intervalOfSpawn);
        }
        
    }

    void SpawnPickupObjects()
    {
        //Randomize spawn location and pickup object being spawned
        Vector3 spawnTransform = new Vector3(horizonalLocation, Random.Range(boundary.minBoundary, boundary.maxBoundary));
        int prefabIndex = Random.Range(0, spawnObjectsPrefabs.Length);

        //As long as player is still alive, spawn pickup objects
        if (GameManager.Instance.IsPlayerDead == false)
        {
            Instantiate(spawnObjectsPrefabs[prefabIndex], spawnTransform, spawnObjectsPrefabs[prefabIndex].transform.rotation);
        }

    }
   
}
