using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class OverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score, highScore, coins;
    [SerializeField] private Button retryButton, menuButton;

    private void Start()
    {
        score.text = GameManager.Instance.currentScore.ToString();
        highScore.text = GameManager.Instance.GetHighScore().ToString();
        coins.text = GameManager.Instance.GetTotalCoins().ToString();
    
        retryButton.onClick.AddListener(HandleRetryClicked);
        menuButton.onClick.AddListener(HandleMenuClicked);
    }

    private void HandleRetryClicked()
    {
        GameManager.Instance.LoadLevel("Game");
    }

    private void HandleMenuClicked()
    {
        GameManager.Instance.LoadLevel("Menu");
    }
}
