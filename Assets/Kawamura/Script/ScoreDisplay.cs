using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreDisplay : MonoBehaviour
{
    public Text _scoreLabel;
    [SerializeField]
    GameObject _titleButton;
    [SerializeField]
    private float _scoreSpeed = 5;
    private float _score0 = 0;
    private float _score1 = 0;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void OnEnable()
    {

        _score0 = GameManager.Instance.TotalDistance / 10;
    }

    private void Update()
    {
        _score1 += _scoreSpeed * Time.deltaTime;
        if(_score1 < _score0)
        {
            _scoreLabel.text = ((int)_score1).ToString() + "m";
        }
        else if(_score1 >= _score0)
        {
            _scoreLabel.text = ((int)_score0).ToString() + "m";
			if( _titleButton )
			{
				_titleButton.SetActive( true );
			}

        }
    }
}