using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    GameObject _titlePanel;
    [SerializeField]
    GameObject _tutrialPanel;
    [SerializeField]
    GameObject _resusltPanel;
    [SerializeField]
    GameObject _inGamePanel;
    [SerializeField]
    GameObject _checkPointPanel;
    [SerializeField]
    GameObject _uiCamera;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.Instance.State)
        {
            case GameState.Title:
                _titlePanel.SetActive(true);
                _tutrialPanel.SetActive(false);
                _resusltPanel.SetActive(false);
                _inGamePanel.SetActive(false);
                _checkPointPanel.SetActive(false);
                Debug.Log(_checkPointPanel);
                _uiCamera.SetActive(true);
                break;

            case GameState.Help:
                _titlePanel.SetActive(false);
                _tutrialPanel.SetActive(true);
                _resusltPanel.SetActive(false);
                _inGamePanel.SetActive(false);
                _checkPointPanel.SetActive(false);
                _uiCamera.SetActive(true);
                break;

            case GameState.InGame:
                _titlePanel.SetActive(false);
                _tutrialPanel.SetActive(false);
                _resusltPanel.SetActive(false);
                _inGamePanel.SetActive(true);
                _checkPointPanel.SetActive(false);
                _uiCamera.SetActive(false);
                break;

            case GameState.CheckPoint:
                _titlePanel.SetActive(false);
                _tutrialPanel.SetActive(false);
                _resusltPanel.SetActive(false);
                _inGamePanel.SetActive(false);
                _checkPointPanel.SetActive(true);
                _uiCamera.SetActive(true);
                break;
                
            case GameState.GameOver:
                _titlePanel.SetActive(false);
                _tutrialPanel.SetActive(false);
                _resusltPanel.SetActive(true);
                _inGamePanel.SetActive(true);
                _checkPointPanel.SetActive(false);
                _uiCamera.SetActive(true);
                break;
        }
    }
}
