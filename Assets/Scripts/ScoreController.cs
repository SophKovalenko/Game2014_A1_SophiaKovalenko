using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TMP_Text scoreText;

    [SerializeField]
    private int playerCurrentScore = 0;

    void Update()
    {
        if (GameManager.Instance.IsPlayerDead == false)
        {
            UpdateScore();
        }

        if (GameManager.Instance.IsPlayerDead == true)
        {
            GameManager.Instance.PlayerScore = playerCurrentScore;
        }

    }

    void UpdateScore()
    {
        playerCurrentScore = GameManager.Instance.Score;
        scoreText.text = "" + playerCurrentScore + " points";
    }
}





