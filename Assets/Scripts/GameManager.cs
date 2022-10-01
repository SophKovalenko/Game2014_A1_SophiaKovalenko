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
    public int Score { get; set; }
    public int Lives { get; set; }
    public bool IsDead { get; set; }

    void Awake()
    {
        instance = this;
    }

    // Set inital properties for variables
    void Start()
    {
        Score = 0;
        Lives = 3;
        IsDead = false;
    }

}