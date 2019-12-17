/*
 2019/12/16
 作成：川崎大樹
 プレイヤー前方向への移動
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


    // Start is called before the first frame update
    void Start()
    {
        _rg = GetComponent<Rigidbody>();
    }
    float speed=2;
    // Update is called once per frame
    void Update()
    {
        //PlayerTurn();
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
        RecodeText.text = "走距離:" + ((int)distance / Time.fixedDeltaTime).ToString();
    }


    void PlayerTurn()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.RotateAround(transform.GetChild(0).transform.position, transform.up, -90);
            _rg.velocity = transform.forward * _rg.velocity.magnitude;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.RotateAround(transform.GetChild(0).transform.position, transform.up, 90);
            _rg.velocity = transform.forward * _rg.velocity.magnitude;
        }
    }
}
