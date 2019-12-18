using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	//<summary>
	//敵のコントローラーです。
	//</summary>

	public ItemManeger.Types type
	{
		get; set;
	}

	GameObject playerPos;

	[SerializeField] float maxSpeed = 6.0f;
	Rigidbody _rg;
	bool deathFlg = false;

    // Start is called before the first frame update
    void Start()
    {
		_rg = GetComponent<Rigidbody>();
		playerPos = GameObject.Find( "PlayerManeger" );
	}

    // Update is called once per frame
    void Update()
    {
		//敵の速度を変えます。
		_rg.velocity = transform.forward * maxSpeed;

	}

	void OnTriggerEnter( Collider other )
	{
		//プレイヤーと衝突したらプレイヤーの死亡フラグが立ちます。
		if( other.gameObject.tag == "Player" )
		{
			deathFlg = true;
		}
	}
}