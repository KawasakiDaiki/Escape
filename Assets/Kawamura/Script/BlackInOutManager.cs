using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackInOutManager : SingletonMonoBehaviour<BlackInOutManager>
{
    [SerializeField]
    GameObject _startButton;
    [SerializeField]
    private float _timeLimit = 4;
    private float _timer = 0;
    

    private void Awake()
    {
        CheckInstance();
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    private void Update()
    {

        _timer += Time.deltaTime;
        if(_timer < _timeLimit && _startButton)
        {
            _startButton.SetActive(false);
        }
        if (_timer >= _timeLimit && _startButton)
        {
            _startButton.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }

    }
}
