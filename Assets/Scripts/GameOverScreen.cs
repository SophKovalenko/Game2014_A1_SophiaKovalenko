//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 1
//  Run Princess, Run! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: October 22nd, 2022
//  Last modified: October 22nd, 2022
//////////////////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text finalScoreText;
    public TMP_Text finalTimeText;

    // Update is called once per frame
    void Update()
    {
        finalScoreText.text = "Final Score: " + ScoreKeeper.totalScore + "";
        finalTimeText.text = "Final Time: " + Mathf.Round(TimeKeeper.totalTime) + " seconds";
    }
}
