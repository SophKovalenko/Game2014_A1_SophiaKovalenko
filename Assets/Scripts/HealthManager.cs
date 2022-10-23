//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 1
//  Run Princess, Run! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: October 21st, 2022
//  Last modified: October 21st, 2022
//  - this script controls the health icons displayed in the game scene based on the players lives
//////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject lifeOnePrefab;
    public GameObject lifeTwoPrefab;
    public GameObject lifeThreePrefab;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Lives == 3)
        {
            lifeOnePrefab.SetActive(true);
            lifeTwoPrefab.SetActive(true);
            lifeThreePrefab.SetActive(true);
        }

        if (GameManager.Instance.Lives == 2)
        {
            lifeOnePrefab.SetActive(true);
            lifeTwoPrefab.SetActive(true);
            lifeThreePrefab.SetActive(false);
        }

        if (GameManager.Instance.Lives == 1)
        {
            lifeOnePrefab.SetActive(true);
            lifeTwoPrefab.SetActive(false);
            lifeThreePrefab.SetActive(false);
        }

        if (GameManager.Instance.Lives == 0)
        {
            lifeOnePrefab.SetActive(false);
            lifeTwoPrefab.SetActive(false);
            lifeThreePrefab.SetActive(false);
        }
    }
}
