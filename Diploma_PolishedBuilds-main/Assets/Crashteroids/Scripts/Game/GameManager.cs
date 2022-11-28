using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public struct ScoreData
    {
        public int score;
        public Text scoreText;
    }

    [SerializeField] private ScoreData _scoreData;

    private void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseScore(int amount)
    {
        _scoreData.score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        _scoreData.scoreText.text = _scoreData.score.ToString();
    }
}
