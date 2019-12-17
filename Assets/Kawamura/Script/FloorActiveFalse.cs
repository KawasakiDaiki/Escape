using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorActiveFalse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("aaaa");
        if (other.CompareTag("PlayerBody"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("iiii");
        }
    }
}
