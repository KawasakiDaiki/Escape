﻿using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームの状態
/// </summary>
public enum GameState
{
    Title,
    Help,
    InGame,
    CheckPoint,
    GameOver
}

/// <summary>
/// ゲーム全体を管理する
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] Text scoreText;
    [SerializeField] GameState gameState;
    public float TotalDistance { get; set; }

   [field:SerializeField] public GameState State { get; set; }

    public int Day { get; set; }

    void Start()
    {
        State = gameState;
    }
    void Update()
    {
        if (scoreText)
        {
            scoreText.text = TotalDistance.ToString("0") + "m";
        }
    }

    public void StartOnClick()
    {
        State = GameState.Help;
        Debug.Log(GameManager.Instance.State);
    }
    public void HelpOnClick()
    {
        State = GameState.InGame;
    }
    public void CheckPointOnClick()
    {
        State = GameState.InGame;
    }
}
