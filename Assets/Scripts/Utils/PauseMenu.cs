using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private GameObject gameMenuCanvas;

    private void Start()
    {
        resumeButton.onClick.AddListener(HandleResumeClicked);
        menuButton.onClick.AddListener(HandleMenuClicked);
    }

    private void Update()
    {
        bool isPaused = GameManager.Instance.IsGamePaused();
        gameObject.SetActive(isPaused);
        gameMenuCanvas.SetActive(!isPaused);
    }

    private void HandleResumeClicked()
    {
        GameManager.Instance.TogglePause();
    }

    private void HandleMenuClicked()
    {
        GameManager.Instance.LoadLevel("Menu");
        GameManager.Instance.IsBackToMenu();
    }
}
