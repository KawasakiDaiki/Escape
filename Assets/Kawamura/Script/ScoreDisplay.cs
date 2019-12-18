using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreDisplay : MonoBehaviour
{
    public Text _ScoreLabel;
    [SerializeField]
    private int _ScoreSpeed = 100;
    private float _Score0 = 10000;
    private float _Score1 = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
         if(_Score0 > _Score1)
        {
            _Score1 += (_ScoreSpeed * Time.deltaTime);
        }
         else if(_Score0 <= _Score1)
        {
            _Score1 =(int)_Score0;
        }
        _ScoreLabel.text = "SCORE:" + ((int)_Score1).ToString();
    }
}
