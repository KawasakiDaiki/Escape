﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public enum EnemyState
    {
        life,
        death,
        stop,
    }
    //敵のオブジェクト
    [SerializeField] GameObject[] enemy;

	//プレイヤーのオブジェクト
	[SerializeField] GameObject player;

	//最高待機時間を設定する
	[SerializeField] float maxWaitTime = 3.0f;
	//基本となる待機時間の変数。日によって変わります。
	float dayMaxWaitTime = 3.0f;
	//
	float dayMinWaitTime = 1.0f;
	//実際に使用する(減算する)変数
	float waitTime = 3.0f;
	//ランダムな時間を代入する変数
	float randomTime = 0f;
	//敵のスポーン頻度を調整する( maxWaitTime - spawnFreq )
	float spawnFreq = 0;

	float dimTime = 0.01f;

	//ランダムで敵の種類を決める変数
	int enemyNumber = 0;
	//スポーンする位置を変える変数
	int spawnSide = 0;
	//敵の種類を制御する変数
	[SerializeField] int enemyTypeVar = 2;

	//敵が生成される場所(プレイヤーとの場所の比較)
	[SerializeField] float distance;

	//敵最大スポーン量
	float spawnMaxVar = 0;
	//敵スポーン数(Random.Range()を使ってランダムに決める)
	int spawnVar = 1;
	//複数敵のスポーンを待つための変数
	int multiSpawnWaitTime = 3;
	//ウェーブの状態
	int waveState = 0;
	//最大のウェーブ
	int bigWave = 0;
	int init = 0;

	
	void Start()
	{
		VariableInit();
	}

	void Update()
	{
		if( GameManager.Instance.State == GameState.InGame )
		{
			UpdateWaitTime();

			UpdateWave();

			UpdateSpawn();

			//if( GameManager.Instance.TotalDistance >= 1000.0f )
			//{
			//	GameManager.Instance.State = GameState.CheckPoint;
			//	VariableInit();
			//}
		}
	}

	void UpdateWaitTime()
	{
		waitTime -= 0.01f;
	}

	void UpdateWave()
	{
		waveSetting();

		if( waveState != 0 )
		{
			return;
		}

		waveState++;
		//GameManager.Instance.Day += 1;
		spawnStart();
		EnemyInit();
	}

	void UpdateSpawn()
	{
		if( waitTime > 0.0f )
		{
			return;
		}

		StartCoroutine(Spawns());
		EnemyInit();
	}

	void waveSetting()
	{
		if( GameManager.Instance.TotalDistance == 350 )
		{
			waveState = 2;
		}
		if( GameManager.Instance.TotalDistance == 700 )
		{
			waveState = 3;
			bigWave += 1;
		}
	}

	//enemy生成
	IEnumerator Spawns()
	{
		for( int i = 0; i < spawnVar; i++ )
		{
			Transform playerPos = player.GetComponent<Transform>();
			float spawnX = playerPos.right.x * spawnSide;
			float spawnY = playerPos.position.y;
			float spawnZ = distance;
			GameObject instantiateEnemy = Instantiate( enemy[ enemyNumber ],
														new Vector3( spawnX, spawnY, spawnZ ),
														Quaternion.Euler( 0, -180, 0 ) );

			instantiateEnemy.GetComponent<EnemyController>().type = ( ItemManeger.Types )( ( int )( enemyNumber / 2 ) );

			Debug.Log( instantiateEnemy.GetComponent<EnemyController>().type );
			Debug.Log( instantiateEnemy.name );
			EnemyInit();

			yield return new WaitForSeconds( 0.5f );

		}
		SpawnQuantity();
		yield break;
	}

	void VariableInit()
	{
		waveState = 0;
		spawnMaxVar = 0;
		spawnVar = 1;
		multiSpawnWaitTime = 3;
		waveState = 0;
		init = 0;

		float dimMaxWaitTime = GameManager.Instance.Day * ( float )0.7;
		if( dimMaxWaitTime <= 1.0f )
		{
			dimMaxWaitTime = 1.0f;
		}

		dayMaxWaitTime = 3.0f - ( GameManager.Instance.Day * ( float )0.7 ) ;
		waitTime = 0.01f;
	}

	//時間、スポーンする敵、スポーンするサイドを変える初期処理のようなもの
	void EnemyInit()
	{
		if( init >= 1 )
		{
			waitTime = dayMaxWaitTime - ( GameManager.Instance.Day * ( float )0.2 );
			init++;
		}
		randomTime = Random.Range( 0f, 2f );
		waitTime += randomTime;
		//Debug.Log( waitTime );
		//Debug.Log( maxWaitTime );
		enemyNumber = Random.Range( 0, 4 );
		spawnSide = Random.Range( -1, 2 );
	}

	void spawnStart()
	{
		spawnMaxVar = 1 + GameManager.Instance.Day * ( float )0.4;
		if( spawnMaxVar > 3.0f )
		{
			spawnMaxVar = 3.0f;
		}
		//Debug.Log( spawnMaxVar );
		waveState = 1;
		bigWave = 0;
	}

	//スポーンの量を決める
	void SpawnQuantity()
	{
		int rangeMin = ( int )( GameManager.Instance.Day * ( float )0.2 );

		if( rangeMin > 3.0f )
		{
			rangeMin = 3;
		}

		int spawnLimit = 0;
		if( ( int )spawnVar <= 4 )
		{
			spawnLimit = 1 + bigWave;
		}

		int rangeMax = ( int )spawnMaxVar + spawnLimit;
		spawnVar = Random.Range( rangeMin, rangeMax );
		Debug.Log( spawnVar );
	}
}
