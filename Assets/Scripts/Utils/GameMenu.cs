using System;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pauseMenuCanvas;

    private void Start()
    {
        pauseButton.onClick.AddListener(HandlePauseClicked);
    }

    private void Update()
    {
        bool isPaused = GameManager.Instance.IsGamePaused();
        gameObject.SetActive(!isPaused);
        pauseMenuCanvas.SetActive(isPaused);
    }

    private void HandlePauseClicked()
    {
        GameManager.Instance.TogglePause();
    }
}
