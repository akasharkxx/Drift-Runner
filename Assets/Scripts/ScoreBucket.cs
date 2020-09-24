using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBucket : MonoBehaviour
{
    [SerializeField] private int scoreAfterSeconds;
    [SerializeField] private TextMeshProUGUI scoreText, scoreToBeat, coinsTotal;

    private int score, currentHighScore, coins;
    private float elapsedTime;

    private void Start()
    {
        score = 0;
        currentHighScore = GameManager.Instance.GetHighScore();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        ScoreIncrementWithTime();

        HighScoreUpdate();
        scoreText.text = score.ToString();
        if (GameManager.Instance.IsPlayerDead)
        {
            GameManager.Instance.SetScore(score);
        }

        coins = GameManager.Instance.GetTotalCoins();
        coinsTotal.text = coins.ToString();
    }

    private void ScoreIncrementWithTime()
    {
        if (Mathf.RoundToInt(elapsedTime) > scoreAfterSeconds * 6)
        {
            scoreAfterSeconds++;
            GameManager.Instance.SetScore(score);
        }
        else
        {
            score += scoreAfterSeconds - 1;
        }
    }

    private void HighScoreUpdate()
    {
        if (score < currentHighScore)
        {
            scoreToBeat.text = "To Beat: \n" + currentHighScore;
        }
        else
        {
            scoreToBeat.text = "New High Score";
        }
    }
}