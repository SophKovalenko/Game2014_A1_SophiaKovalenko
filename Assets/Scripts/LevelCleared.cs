//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 1
//  Run Princess, Run! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: October 22nd, 2022
//  Last modified: October 22nd, 2022
//  - this script stores the variables needed for the levels cleared scenes
//////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCleared : MonoBehaviour
{
    public TMP_Text finalScoreText;

    // Update is called once per frame
    void Update()
    {
        finalScoreText.text = "Final Score: " + ScoreKeeper.totalScore + "";
    }
}


