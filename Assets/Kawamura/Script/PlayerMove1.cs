/*
 2019/12/16
 作成：川崎大樹
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour
{
    [SerializeField]
    private float MaxSpeed;
    Rigidbody _rg;
    public int _MoveCount_x = 0; //プレイヤーの横移動制限


    // Start is called before the first frame update
    void Start()
    {
        _rg = GetComponent<Rigidbody>();
    }
    float speed = 1;

    // Update is called once per frame
    void Update()
    {
        if (_rg.velocity.magnitude < MaxSpeed )
        {
            _rg.AddForce(transform.forward * speed);
        }
        else
        {
            _rg.velocity = transform.forward * 10;
        }

        if (Input.GetKeyDown(KeyCode.A) && (_MoveCount_x < 1))//左移動
        {
            _MoveCount_x++;
            transform.position -= transform.right;
            
        }
        if (Input.GetKeyDown(KeyCode.D) && (_MoveCount_x > -1))
        {
            _MoveCount_x--;
            transform.position += transform.right;
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("aaaa");
        if (other.CompareTag("Ground"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("iiii");
        }
    }
}