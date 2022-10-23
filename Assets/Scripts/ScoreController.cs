//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 1
//  Run Princess, Run! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: October 22nd, 2022
//  Last modified: October 22th, 2022
//  - this script displays the players score on screen via text
//////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TMP_Text scoreText;

    [SerializeField]
    private int playerCurrentScore = 0;

    void Start()
    {
        ScoreKeeper.totalScore = 0;
    }

    void Update()
    {
        if (GameManager.Instance.IsPlayerDead == false)
        {
            UpdateScoreText();
        }

    }

    void UpdateScoreText()
    {
        playerCurrentScore = ScoreKeeper.totalScore;
        scoreText.text = "" + playerCurrentScore + " points";
    }
}





