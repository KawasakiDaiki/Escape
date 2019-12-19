using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackInOutSlider : MonoBehaviour
{
    [SerializeField]
    private float _blackInOutSpeed;
    [SerializeField]
    private float timeLimit = 4;
    private Vector3 _resetPosition;
    private float timer = 0;

    void Awake()
    {

        _resetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(_blackInOutSpeed, 0, 0) * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer >= timeLimit)
        {
            transform.position = _resetPosition;
        }

    }
}
