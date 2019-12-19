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
    [SerializeField] GameObject _nextStageButton;
    [SerializeField] GameState gameState;
    [SerializeField] PlayerAnimationController playerAnimator;
    public float TotalDistance { get; set; }

    [field: SerializeField] public GameState State { get; set; }

    public int Day { get; set; }

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
            scoreText.text = (TotalDistance / 10).ToString("0.0") + "m";
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
    public void CheckPointOnClick()
    {
        _nextStageButton.SetActive(false);
        State = GameState.InGame;
        playerAnimator.StopRun();
    }
	public void CheckPoint()
    {
        State = GameState.CheckPoint;
    }
}
