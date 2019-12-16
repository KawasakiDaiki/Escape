using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawn : MonoBehaviour
{

	GameObject cameraObject;

    // Start is called before the first frame update
    void Start()
    {
		cameraObject = GameObject.FindGameObjectWithTag( "MainCamera" );
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 cameraPos = cameraObject.transform.position;
		

    }
}
