using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType : MonoBehaviour
{

    public ItemManeger.Types type { get; set; }


    float speedPreset = 0;
    float lifeLimit = 3f;//死ぬまで


    // Update is called once per frame
    void Update()
    {
        Move();
    }


    //自身の移動
    void Move()
    {
        transform.position += new Vector3(0, 0, (GameManager.Instance.PlayerSpeed+speedPreset) * Time.deltaTime);
    }

    public void StartCol()
    {
        StartCoroutine(LifeCount());
    }

    //時間経過で自己消滅、画面外に移動
    IEnumerator LifeCount()
    {
        yield return new WaitForSeconds(lifeLimit);
        ItemManeger.ReturnPool(this.gameObject);
    }
}
