using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectActive : MonoBehaviour
{
    public GameObject _Object0;
    public GameObject _Object1;
    private bool _Repeated = true;

    public void ActiveObject()
    {
        if (_Repeated)
        {
            _Object0.SetActive(true);
            _Object1.SetActive(true);
            _Repeated = false;
        }
    }
}
