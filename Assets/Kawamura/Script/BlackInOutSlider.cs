using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackInOutSlider : MonoBehaviour
{
    [SerializeField]
    private float _BlackInOutSpeed;
    // Update is called once per frame
    private void Update()
    {
        transform.position -= new Vector3(_BlackInOutSpeed, 0,0) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
    }
}
