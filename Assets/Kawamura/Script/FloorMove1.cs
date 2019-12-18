using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove1 : MonoBehaviour
{
    [SerializeField]
    private float _maxSpeed;
    Rigidbody _rg;
    public int _MoveCount_x { get; private set; }
    //プレイヤーの横移動制限


    // Start is called before the first frame update
    void Start()
    {
        _rg = GetComponent<Rigidbody>();
    }
    float _speed = 1;

    // Update is called once per frame
    public void Update()
    {
    if (_rg.velocity.magnitude < _maxSpeed)
        {
            _rg.AddForce(transform.forward * _speed);
        }
        else
        {
            _rg.velocity = transform.forward * 30;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("aaaa");
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("iiii");
        }
    }
}