using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform TargetPosition;
    public Transform LookTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,TargetPosition.transform.position,0.5f);
        transform.LookAt(LookTarget, LookTarget.transform.up);
    }
}
