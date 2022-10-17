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
    public void OnInstructionsButtonClicked()
    {
        SceneManager.LoadScene("Instructions");
    }


    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Level1GameScreen");
    }

    public void OnContinueButtonClicked()
    {
        SceneManager.LoadScene("Level2GameScreen");
    }

    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnExitButtonClicked()
    {
        //Quit the game if running as app
        Application.Quit();

        //Quit the game if running in editor
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
