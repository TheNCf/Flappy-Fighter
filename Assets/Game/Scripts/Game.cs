using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private RocketSpawner _playerRocketSpawner;
    [SerializeField] private RocketSpawner _enemyRocketSpawner;
    [SerializeField] private GameStartScreen _gameStartScreen;
    [SerializeField] private GameEndScreen _gameEndScreen;

    private void OnEnable()
    {
        _gameStartScreen.PlayButtonClicked += OnPlayButtonPressed;
        _gameEndScreen.RestartButtonClicked += OnRestartButtonPressed;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _gameStartScreen.PlayButtonClicked -= OnPlayButtonPressed;
        _gameEndScreen.RestartButtonClicked -= OnRestartButtonPressed;
        _player.GameOver -= OnGameOver;
    }

    private void OnRestartButtonPressed()
    {
        _gameEndScreen.Close();
        _gameStartScreen.Open();
        _enemySpawner.ReleaseAll();
        _playerRocketSpawner.ReleaseAll();
        _enemyRocketSpawner.ReleaseAll();
        StartGame();
    }

    private void OnPlayButtonPressed()
    {
        _gameStartScreen.Close();
        StartGame();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0.0f;
        _gameEndScreen.Open();
    }

    private void StartGame()
    {
        Time.timeScale = 1.0f;
    } 
}
