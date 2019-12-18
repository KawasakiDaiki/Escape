using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManagement : MonoBehaviour
{
    [SerializeField]
    private float _transformReset = -60;
    [SerializeField]
    private float _resetPosition = -240;
    [SerializeField]
    private float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform item in transform)
        {
            item.localPosition += Vector3.forward * 1f * Time.deltaTime;
            if (item.localPosition.z > 60)
            {
                item.localPosition += Vector3.forward * -240;
            }
        }
    }
}
