using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public void StartButton()
    {
        GameManager.Instance.State = GameState.Help;
    }
}
