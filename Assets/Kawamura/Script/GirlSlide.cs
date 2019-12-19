using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlSlide : MonoBehaviour
{
    [SerializeField]
    GameObject _nextStageButton;
    [SerializeField]
    private float _speed;
    private float _move_x;
    private Vector3 _resetTransform;
    // Update is called once per frame
    
    private void Start()
    {
        _resetTransform = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    void Update()
    {
        _move_x = _speed * Time.deltaTime;
        this.gameObject.transform.position += new Vector3(_move_x,0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        transform.position = _resetTransform;
        this.gameObject.SetActive(false);
        _nextStageButton.gameObject.SetActive(true);
    }
    
}
