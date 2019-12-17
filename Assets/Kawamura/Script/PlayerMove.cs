/*
 2019/12/16
 作成：川崎大樹
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
​
public class PlayerMove : MonoBehaviour
{
    Rigidbody _rg;

    // Start is called before the first frame update
    void Start()
    {
        _rg = GetComponent<Rigidbody>();
    }
    float speed = 1;

    // Update is called once per frame
    void Update()
    {
        if (_rg.velocity.magnitude < 10)
        {
            _rg.AddForce(transform.forward * speed);
        }
        else
        {
            _rg.velocity = transform.forward * 10;
        }
​
​
​
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position -= transform.right;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += transform.right;
        }
    }
}