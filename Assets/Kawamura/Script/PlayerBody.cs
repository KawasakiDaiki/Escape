using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    Rigidbody _rg;
    public int _MoveCount_x { get; private set; }
    //プレイヤーの横移動制限


    // Start is called before the first frame update
    void Start()
    {
        _rg = GetComponent<Rigidbody>();
    }
    float speed = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && (_MoveCount_x < 1))//左移動
        {
            _MoveCount_x++;
            transform.position -= transform.right * 2;

        }
        if (Input.GetKeyDown(KeyCode.D) && (_MoveCount_x > -1))
        {
            _MoveCount_x--;
            transform.position += transform.right * 2;

        }
    }
}