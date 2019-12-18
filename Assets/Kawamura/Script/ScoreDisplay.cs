using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreDisplay : MonoBehaviour
{
    public Text _scoreLabel;
    [SerializeField]
    private int _scoreSpeed = 100;
    private float _score0 = 10000;
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
            _score1 += (_scoreSpeed * Time.deltaTime);
        }
         else if(_score0 <= _score1)
        {
            _score1 =(int)_score0;
        }
        _scoreLabel.text = "SCORE:" + ((int)_score1).ToString();
    }
}
