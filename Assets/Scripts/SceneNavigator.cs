using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
