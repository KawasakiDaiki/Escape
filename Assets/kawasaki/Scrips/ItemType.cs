using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType : MoveBase
{

    public ItemManeger.Types type { get; set; }


    float speedPreset = 0;
    float lifeLimit = 1.5f;//死ぬまで
    IEnumerator LifeCoroutine;

    //active時
    void OnEnable()
    {
        LifeCoroutine=LifeCount();
        StartCoroutine(LifeCoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //自身の移動
    public override void Move()
    {
        transform.position += new Vector3(0, 0, (BaseSpeed+speedPreset) * Time.deltaTime);
        if (transform.position.y > 0.1f)
        {
            transform.position -= new Vector3(0, 0.01f+Time.deltaTime, 0);
        }
    }

    //時間経過で自己消滅、画面外に移動
    IEnumerator LifeCount()
    {
        yield return new WaitForSeconds(lifeLimit);
        gameObject.SetActive(false);
        transform.position = new Vector3(100, 100, 100);
    }


    ////Enemyと当たったら
    //public override void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.tag == "Enemy")
    //    {
    //        if (col.gameObject.GetComponent<EnemyController>().type == type)
    //        {
    //            col.gameObject.GetComponent<EnemyController>().state = EnemySpawner.EnemyState.death;

    //            col.GetComponent<EnemyController>().StartDesEvent();
               
    //            //col.gameObject.GetComponent<EnemyController>().DesEfect();
    //            LifeCoroutine = null;//コルーチン停止
    //            gameObject.SetActive(false);
    //        }
    //    }
    //}
}
