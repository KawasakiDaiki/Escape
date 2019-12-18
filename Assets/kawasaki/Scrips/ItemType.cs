using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType : MonoBehaviour
{
    public ItemManeger.Types type { get; set; }

    float speed = 10.0f;
    float lifeLimit = 5.0f;// lifeLimit/speed
    IEnumerator LifeCoroutine;

    void OnEnable()
    {
        LifeCoroutine=LifeCount();
        StartCoroutine(LifeCoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, speed*Time.deltaTime);
    }


    IEnumerator LifeCount()
    {
        yield return new WaitForSeconds(lifeLimit/speed);
        gameObject.SetActive(false);
        transform.position = new Vector3(100, 100, 100);
    }



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (col.gameObject.GetComponent<EnemyController>().type == ItemManeger.Types.money|| col.gameObject.GetComponent<EnemyController>().type == type)
            {
                Debug.Log("hit");
                Destroy(col.gameObject);
                LifeCoroutine = null;
                gameObject.SetActive(false);
            }
        }
    }
}
