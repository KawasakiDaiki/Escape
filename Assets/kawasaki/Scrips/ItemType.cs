using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType : MonoBehaviour
{
    public ItemManeger.Types type { get; set; }

    IEnumerator LifeCoroutine;
    // Start is called before the first frame update
    void Start()
    {
    }
    void OnEnable()
    {
        LifeCoroutine=LifeCount();
        StartCoroutine(LifeCoroutine);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator LifeCount()
    {
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col);
            LifeCoroutine = null;
            gameObject.SetActive(false);
        }
    }
}
