using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackInOutSlider : MonoBehaviour
{
    [SerializeField]
    private float _BlackInOutSpeed;
    [SerializeField]
    private float timeLimit = 4;
    private float timer = 0;

    // Update is called once per frame
    private void Update()
    {
        transform.position -= new Vector3(_BlackInOutSpeed, 0,0) * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer <= timeLimit)
        {
            this.gameObject.SetActive(false);
        }

    }
}
