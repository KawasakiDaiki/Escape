using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButton : MonoBehaviour
{

    [SerializeField]
    GameObject _uiCamera;
    [SerializeField]
    GameObject _gameStartMana;
    // Update is called once per frame
   public void HelpPush()
    {
        if (GameManager.Instance.State == GameState.InGame)
        {
            _gameStartMana.SetActive(true);
            _uiCamera.SetActive(false);
        }
        else
        {
            _gameStartMana.SetActive(false);
            _uiCamera.SetActive(true);
        }
    }
}
