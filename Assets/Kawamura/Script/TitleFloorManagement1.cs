using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleFloorManagement1 : MonoBehaviour
{

    [SerializeField]
    private float _transformReset = -60;
    [SerializeField]
    private float _resetPosition = -240;
    [SerializeField]
    private float _speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        foreach (Transform item in transform)
        {
            item.localPosition += Vector3.forward * _speed * Time.deltaTime;
            if (item.localPosition.z > _transformReset)
            {
                item.localPosition = Vector3.forward * _resetPosition;
            }
        }
    }
}
