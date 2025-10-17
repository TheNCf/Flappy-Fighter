using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreText.text = score.ToString();
    }
}
