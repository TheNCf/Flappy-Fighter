using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameStartScreen _gameStartScreen;
    [SerializeField] private GameEndScreen _gameEndScreen;

    private void OnEnable()
    {
        _gameStartScreen.PlayButtonClicked += OnPlayButtonPressed;
        _gameEndScreen.RestartButtonClicked += OnRestartButtonPressed;
    }

    private void OnDisable()
    {
        _gameStartScreen.PlayButtonClicked -= OnPlayButtonPressed;
        _gameEndScreen.RestartButtonClicked -= OnRestartButtonPressed;
    }

    private void OnRestartButtonPressed()
    {
        _gameEndScreen.Close();
        StartGame();
    }

    private void OnPlayButtonPressed()
    {
        _gameStartScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1.0f;
    } 
}
