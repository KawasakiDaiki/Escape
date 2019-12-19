using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MoveBase
{

    public enum EnemyState
    {
        life,
        death,
        stop,
    }
    public ItemManeger.Types type{get; set;}
    public /*EnemySpawner.*/EnemyState state;

	float speed = 10.5f;
	Rigidbody _rg;
	bool deathFlg = false;

    void Update()
    {
        Move();
    }

    public override void Move()
    {
        switch (state)
        {
            //生きている間は手前側に
            case /*EnemySpawner.*/EnemyState.life:
                MoveMyself(-speed);
                break;
            //死んだら地面と同じベクトルに
            case /*EnemySpawner.*/EnemyState.death:
                MoveMyself(BaseSpeed);
                break;
            //停止
            case /*EnemySpawner.*/EnemyState.stop:
                break;
        }
    }
    //移動処理、speedの速度でz方向へ
    void MoveMyself(float speed)
    {
        transform.position += new Vector3(0, 0, speed*Time.deltaTime);
    }

    /// <summary>
    /// 敵の死亡アニメーション
    /// </summary>
    /// <remarks>
    /// アイテムと当たったらアイテム側からコール
    /// </remarks>
    public void DeathAni()
    {
        GetComponent<Animator>().SetTrigger(0);
    }
    //疑似アニメーション後処理
    public IEnumerator DesEvent()
    {
        yield return new WaitForSeconds(1.5f);

        DestroyEvent();
    }

    //アニメーション後に破壊する用
    void DestroyEvent()
    {
        Destroy(this.gameObject);
    }
    //Enemyと当たったら
    public override void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Seed")
        {
            if (col.gameObject.GetComponent<ItemType>().type == type)
            {
                state = /*EnemySpawner.*/EnemyState.death;
                StartCoroutine(DesEvent());

                ItemManeger.HitEnemy(col.gameObject);
            }
        }
    }
    //ゲームオーバー処理
    void OnTriggerStay( Collider other )
	{
		if( other.gameObject.tag == "Player" )
		{
			deathFlg = true;
			Debug.Log( deathFlg );
		}
	}
    
}
