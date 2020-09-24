using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [HideInInspector] public int currentScore, currentCoins;
    private int highScore, coinsTotal;
    private bool isPlayerDead;

    public enum GameState
    {
        PREGAME,
        RUNNING,
        PAUSED
    }

    private string currentLevelName = string.Empty;
    GameState currentGameState = GameState.PREGAME;

    public GameState CurrentGameState
    {
        get { return currentGameState; }
        private set { currentGameState = value; }
    }
    public bool IsPlayerDead
    {
        get { return isPlayerDead; }
        set { isPlayerDead = value; }
    }
    //end variable declaration
    
    private void Start()
    {
        isPlayerDead = false;
        DontDestroyOnLoad(gameObject);
    }
    
    private void Update()
    {
        if (currentGameState == GameState.PREGAME)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && currentGameState != GameState.PREGAME)
        {
            TogglePause();
        }
    }

    #region GameState

    private void UpdateState(GameState state)
    {
        GameState previousGameState = currentGameState;
        currentGameState = state;

        switch (currentGameState)
        {
            case GameState.PREGAME:
                Time.timeScale = 1.0f;
                break;
            case GameState.RUNNING:
                Time.timeScale = 1.0f;
                break;
            case GameState.PAUSED:
                Time.timeScale = 0.0f;
                break;
            default:
                break;
        }
    }

    public void StartGame()
    {
        LoadLevel("Game");
        UpdateState(GameState.RUNNING);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadSceneAsync(levelName);
    }

    public void TogglePause()
    {
        UpdateState(currentGameState == GameState.RUNNING ? GameState.PAUSED : GameState.RUNNING);
    }

    public bool IsGamePaused()
    {
        if (currentGameState == GameState.PAUSED)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void IsBackToMenu()
    {
        UpdateState(GameState.PREGAME);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion

    #region ScoreCode
    public void SetScore(int scoreValue)
    {
        currentScore = scoreValue;
        if (currentScore > GetHighScore())
        {
            highScore = currentScore;
            StoreScore();
        }
    }

    public int GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        return highScore;
    }

    private void StoreScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }
    #endregion

    #region CoinCode
    public void AddCollectedCoins(int coinsToAdd)
    {
        coinsTotal = GetTotalCoins();
        coinsTotal += coinsToAdd;
        currentCoins += coinsToAdd;
        SaveCoins();
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", coinsTotal);
    }

    public int GetTotalCoins()
    {
        coinsTotal = PlayerPrefs.GetInt("Coins");
        return coinsTotal;
    }
    #endregion
}
