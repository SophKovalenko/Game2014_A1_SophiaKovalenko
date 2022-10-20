//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 1
//  Run Princess, Run! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: October 18th, 2022
//  Last modified: October 18th, 2022
//////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private float startingTime = 0;
    private TMP_Text timerText;
    private int playerFinalTime;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsPlayerDead == false)
        {
            float dt = Time.deltaTime;
            startingTime += dt;
            UpdateTimer();
        }

        if (GameManager.Instance.IsPlayerDead == true)
        {
            GameManager.Instance.FinalTime = playerFinalTime;
        }

    }

    void UpdateTimer()
    {
        timerText.text = "" + Mathf.Round(startingTime) + " seconds";
    }
}
