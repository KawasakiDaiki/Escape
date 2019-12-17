using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform Traget;
    public Transform LookTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Traget.position, 0.5f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Traget.rotation, 0.3f);
    }
}
