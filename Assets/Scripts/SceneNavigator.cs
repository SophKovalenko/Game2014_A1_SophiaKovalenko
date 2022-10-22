//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 1
//  Run Princess, Run! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: October 2nd, 2022
//  Last modified: October 22th, 2022
//////////////////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    private AudioSource UIAudio;
    public AudioClip buttonClick;

    public void Start()
    {
     UIAudio = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (GameManager.Instance.IsPlayerDead == true)
        {
            SceneManager.LoadScene("GameLostScreen");
        }

        if (TimeKeeper.totalTime >= 120.0f && TimeKeeper.isCurrentLevel2 == false)
        {
            ChangeLevelOne();
            TimeKeeper.isCurrentLevel2 = true;
        }

        if (TimeKeeper.totalTime >= 180.0f && TimeKeeper.isCurrentLevel2 == true)
        {

            ChangeLevelTwo();
        }

    }

    public void PlayUIAudio()
    {
        UIAudio.PlayOneShot(buttonClick, 1.0f);
    }

    public void OnInstructionsButtonClicked()
    {
        SceneManager.LoadScene("Instructions");
        PlayUIAudio();
    }


    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Level1GameScreen");
        PlayUIAudio();
    }

    public void OnContinueButtonClicked()
    {
        SceneManager.LoadScene("Level2GameScreen");
        PlayUIAudio();
    }

    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
        PlayUIAudio();
    }

    public void OnExitButtonClicked()
    {
        PlayUIAudio();

        //Quit the game if running as app
        Application.Quit();

        //Quit the game if running in editor
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void ChangeLevelOne()
    {
        TimeKeeper.totalTime = 0;
        SceneManager.LoadScene("LevelWon");
    }

    public void ChangeLevelTwo()
    {
        TimeKeeper.totalTime = 0;
        SceneManager.LoadScene("GameWon");
    }
}
