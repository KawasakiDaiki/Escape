using UnityEngine;
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
    [SerializeField] Text scoreLabel;
    [SerializeField] GameObject _nextStageButton;
    [SerializeField] GameState gameState;
    [SerializeField] PlayerAnimationController playerAnimator;
    public float TotalDistance { get; set; }

    [field: SerializeField] public GameState State { get; set; }

    public bool Death { get; set; }

    public float[] _stageLength = { 100, 150, 200, 250, 300, 350, 400 };

    public int Day { get; set; } = 0;

    public float PlayerSpeed { get; set; }
    float speed = 10;

    void Awake()
    {
        CheckInstance();
        PlayerSpeed = speed;
    }
    void Start()
    {
        State = gameState;
    }
    void Update()
    {
        if (State == GameState.InGame)
        {
            RenderSettings.fog = true;
            scoreLabel.text = "お家まで" + (_stageLength[Day] - (TotalDistance / 10)).ToString("0.0") + "m";
            scoreText.text = "お家まで" + (_stageLength[Day] - (TotalDistance / 10)).ToString("0.0") + "m";
            if (Death)
            {
                GameOver();
            }
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
        playerAnimator.PlayRun();
    }
    public void StageClear()
    {
        if (TotalDistance / 10 >= _stageLength[Day])
        {
            State = GameState.CheckPoint;
            TotalDistance = 0;
            RenderSettings.fog = false;
            playerAnimator.StopRun();
        }
    }
    public void CheckPointOnClick()
    {
        _nextStageButton.SetActive(false);
        State = GameState.InGame;
        playerAnimator.PlayRun();
        TotalDistance = 0;
        Day++;
        if (Day >= 7)
        {
            Day = 0;
        }
    }
    //public void CheckPoint()
    //   {
    //       State = GameState.CheckPoint;
    //  TotalDistance = 0;

    //}

    public void GameOver()
    {
        State = GameState.GameOver;
        playerAnimator.StopRun();
    }
}
