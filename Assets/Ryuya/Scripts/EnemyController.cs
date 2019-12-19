/*
 更新日:2019/12/19
 更新者:川崎大樹
 移動処理をRigidbody→transformに
 死亡処理、間違ったアイテムを投げられた時の処理追加
 */

using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public ItemManeger.Types type{get; set;}
    public EnemySpawner.EnemyState state;

	float speed = 12.0f;

    float dashSpeed = 15.0f;
    bool dashFlg = false;
    float dashTime = 0.5f;

	bool deathFlg = false;

    void Start()
    {
        speed = GameManager.Instance.PlayerSpeed * 0.5f;
        dashSpeed= GameManager.Instance.PlayerSpeed * 1.0f;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        switch (state)
        {
            //生きている間は手前側に
            case EnemySpawner.EnemyState.life:
                LifeMove();
                break;


            //死んだら地面と同じベクトルに
            case EnemySpawner.EnemyState.death:
                DeathMove();
				StartCoroutine( DesEvent() );
				break;


            //停止
            case EnemySpawner.EnemyState.stop:
				//DeathAni();
				//StartCoroutine( DesEvent() );
                break;
        }
    }
    // 状態ごとの動き
    void LifeMove()
    {
        if (!dashFlg)
        {
            MoveMyself(-speed);
        }
        else
        {
            MoveMyself(-dashSpeed);
        }
    }
    void DeathMove()
    {
        MoveMyself(GameManager.Instance.PlayerSpeed);
    }
    //void Stop()
    //{

    //}

    //speed毎秒で移動
    void MoveMyself(float speed)
    {
        transform.position += Vector3.forward * (speed * Time.deltaTime);
    }

    /// <summary>
    /// 敵の死亡アニメーション
    /// </summary>
    /// <remarks>
    /// アイテムと当たったらアイテム側からコール
    /// </remarks>
    public void DeathAni()
    {
        GetComponent<Animator>().SetTrigger( "DeathTrigger" );
		Debug.Log( "true" );
    }

    //疑似アニメーション後処理
    public IEnumerator DesEvent()
    {
		DeathAni();
        yield return new WaitForSeconds(1.5f);

        CallDesEffect();
    }
    IEnumerator Dash()
    {
        dashFlg = true;
        //GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(dashTime*2/3);
        //GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(dashTime*1/3);
        dashFlg = false;
    }

    //Enemyと当たったら
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Seed")
        {
			if (col.gameObject.GetComponent<ItemType>().type == type)
            {
                state = EnemySpawner.EnemyState.death;
				//StartCoroutine(DesEvent());
                ItemManeger.ReturnPool(col.gameObject);
            }
            else
            {
                StartCoroutine(Dash());
            }
        }
    }

	//敵デストロイ
	public void DestroyEnemy() {

		CallDesEffect();

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
    
    //アニメーション後に破壊する用
    void CallDesEffect()
    {
        Destroy(this.gameObject);
    }
    
}
