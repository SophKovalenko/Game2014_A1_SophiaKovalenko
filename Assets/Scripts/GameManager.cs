//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 1
//  Run Princess, Run! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: October 2nd, 2022
//  Last modified: October 22nd, 2022
// - this script manages the game info related to player lives
// - stores important bools needed for player behaviour in each level
//////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Create one instance of game using singleton
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject startGame = new GameObject("GameManager");
                startGame.AddComponent<GameManager>();
            }
            return instance;
        }

    }

    //Use this manager to track Score, Lives and Game Lost condition
    public int Lives { get; set; }
    public bool IsPlayerInvincible { get; set; }
    public bool HasPlayerSpedUp { get; set; }
    public bool IsPlayerDead { get; set; }
    public bool IsEnemyDestroyed { get; set; }

    void Awake()
    {
        instance = this;
        
    }

    // Set inital properties for variables
    void Start()
    {
        Lives = 3;
        IsPlayerInvincible = false;
        HasPlayerSpedUp = false;
        IsPlayerDead = false;
        IsEnemyDestroyed = false;
    }

}
