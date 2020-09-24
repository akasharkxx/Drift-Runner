using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(HandleStartClicked);
    }

    private void HandleStartClicked()
    {
        GameManager.Instance.StartGame();
    }
}
