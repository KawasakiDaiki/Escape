using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerActive : MonoBehaviour
{
    public GameObject _Timer;

    private void TimerStart()
    {
        _Timer.SetActive(true);
    }
}
