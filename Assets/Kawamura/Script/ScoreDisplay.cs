using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreDisplay : MonoBehaviour
{
    public Text _scoreLabel;
    [SerializeField]
    private int _scoreSpeed = 100;
    private float _score0 = GameManager.Instance.TotalDistance / 10;
    private float _score1 = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(_score0 > _score1)
        {
            _score1 += _scoreSpeed * Time.deltaTime;
            _scoreLabel.text = "SCORE" + _score1.ToString() + "m";
        }
        if(_score0 <= _score1)
        {
            _scoreLabel.text = _score0.ToString("m");
        }
        _scoreLabel.text = (GameManager.Instance.TotalDistance / 10 ).ToString("0.0") + "m";
    }
}
