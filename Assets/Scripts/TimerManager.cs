//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 1
//  Run Princess, Run! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: October 18th, 2022
//  Last modified: October 22nd, 2022
//////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private TMP_Text timerText;
    public float playerCurrentTime = 0;

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
            UpdateTimer();
        }

    }

    void UpdateTimer()
    {
        float dt = Time.deltaTime;
        playerCurrentTime += dt;

        timerText.text = "" + Mathf.Round(playerCurrentTime) + " seconds";

        TimeKeeper.totalTime = playerCurrentTime;
    }
}
