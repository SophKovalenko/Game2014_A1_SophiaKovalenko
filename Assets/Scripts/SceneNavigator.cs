//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 1
//  Run Princess, Run! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: October 2nd, 2022
//  Last modified: October 16th, 2022
//////////////////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        { 
            SceneManager.LoadScene("MainMenu"); 
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene("Instructions");
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("Level1GameScreen");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("Level2GameScreen");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("GameLostScreen");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene("GameWon");
        }
    }
}
