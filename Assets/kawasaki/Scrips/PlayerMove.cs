/*
 2019/12/16
 作成：川崎大樹
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public Text RecodeText;

    Rigidbody _rg;
    private float maxSpeed=5;
    private float distance = 0;

    private int NowLine = 0;
    // Start is called before the first frame update
    void Start()
    {
        _rg = GetComponent<Rigidbody>();
    }
    float speed=2;
    // Update is called once per frame
    void Update()
    {
        WideMovar();
    }
    void FixedUpdate()
    {
        //mazSpeedまでは加速
        if (_rg.velocity.magnitude < maxSpeed)
        {
            _rg.AddForce(transform.forward * speed);
        }
        else//mazSpeed以上ならmaxSpeed固定
        {
            _rg.velocity = transform.forward * maxSpeed;
        }

        distance += _rg.velocity.magnitude;
        RecodeText.text = "走距離:" + ((int)distance / 100).ToString();
    }
    void WideMovar()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (NowLine > -1)
            {
                transform.position -= transform.right;
                NowLine--;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (NowLine < 1)
            {
                transform.position += transform.right;
                NowLine++;
            }
        }
    }
}
