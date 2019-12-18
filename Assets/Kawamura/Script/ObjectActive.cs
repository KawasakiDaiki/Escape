using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectActive : MonoBehaviour
{
    public GameObject _Object0;
    public GameObject _Object1;
    private bool _repeated = true;

    public void ActiveObject()
    {
        if (_repeated)
        {
            _Object0.SetActive(true);
            _Object1.SetActive(true);
            _repeated = false;
        }
    }
}
