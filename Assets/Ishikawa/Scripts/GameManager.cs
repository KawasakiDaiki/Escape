using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] Text scoreText;
    public int Score { get; set; }
    public float TotalDistance { get; set; }

    void Update()
    {
        scoreText.text = TotalDistance.ToString("0") + "m";
    }
}
