using System.Collections;
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

	//基本となる待機時間の変数。そのうちこちらもタイミング変更で変えていきます。
	private float maxWaitTime = 3.0f;
	//実際に使用する(減算する)変数
	private float waitTime = 3.0f;
	//ランダムな時間を代入する変数
	private float randomTime = 0f;
	private float dimTime = 0.01f;

	//ランダムで敵の種類を決める変数
	private int enemyNumber = 0;
	//スポーンする位置を変える変数
	private int spawnSide = 0;
	//敵の種類を制御する変数
	[SerializeField] int enemyTypeVar = 0;

	//UIのサイズ定数
	const float uiSizeX = 100;
	const float uiSizeY = 100;
	//UIのサイズを変える変数
	private float uiSizeMove = 0;

	[SerializeField] float distance = 10.0f;

	//敵最大スポーン量
	float spawnMaxVar = 0;
	//敵スポーン数(Random.Range()を使ってランダムに決める)
	int spawnVar = 1;
	//複数敵のスポーンを待つための変数
	int multiSpawnWaitTime = 3;
	//ウェーブの状態
	int waveState = 0;

	
	void Start()
	{

	}
	

	void Update()
	{
		UpdateWaitTime();

		UpdateWave();

		UpdateSpawn();

		if( GameManager.Instance.TotalDistance >= 1000 )
		{
			GameManager.Instance.State = GameState.CheckPoint;
		}
	}

	void UpdateWaitTime()
	{
		waitTime -= 0.01f;
	}

	void UpdateWave()
	{

		if( GameManager.Instance.TotalDistance == 350 )
		{
			waveState = 2;
		}
		if( GameManager.Instance.TotalDistance == 700 )
		{
			waveState = 3;
		}

		if( waveState != 0 )
		{
			return;
		}
		waveState++;
		GameManager.Instance.Day++;
		spawnStart();
		Debug.Log( "true" );
		EnemyInit();
	}

	void UpdateSpawn()
	{
		if( waitTime > 0.0f )
		{
			return;
		}

		Spawn();
	}

	void Spawn()
	{
		for( int i = 0; i < spawnVar; i++ )
		{
			Transform playerPos = player.GetComponent<Transform>();
			float spawnX = playerPos.right.x * spawnSide;
			float spawnY = playerPos.position.y;
			float spawnZ = distance;
			GameObject instantiateEnemy = Instantiate( enemy[ enemyNumber ],
														new Vector3( spawnX, spawnY, spawnZ ),
														player.transform.rotation );

            instantiateEnemy.GetComponent<EnemyController>().type = (ItemManeger.Types)enemyNumber;

			EnemyInit();
		}

		//if( multiSpawnWaitTime++ >= 3 )
		//{
		spawnVar = Random.Range( ( int )( GameManager.Instance.Day / ( float )0.2 ), ( int )spawnMaxVar + 1 );
		Debug.Log( spawnMaxVar );
		//Debug.Log( GameManager.Instance.TotalDistance );
			//multiSpawnWaitTime = 3;
			//multiSpawnWaitTime++;
			//if( spawnVar >= 2 )
			//{
			//	multiSpawnWaitTime = 3;
			//}
		//}
	}

	//時間、スポーンする敵、スポーンするサイドを変える初期処理のようなもの
	void EnemyInit()
	{
		waitTime = maxWaitTime - ( GameManager.Instance.Day * ( float )0.2 );
		randomTime = Random.Range( 0f, 2f );
		waitTime += randomTime;
		enemyNumber = Random.Range( 0, enemyTypeVar);
		spawnSide = Random.Range( -1, 2 );
	}

	void spawnStart()
	{
		spawnMaxVar = GameManager.Instance.Day * ( float )0.4;
		if( spawnMaxVar > 3.0f )
		{
			spawnMaxVar = 3.0f;
		}
		//Debug.Log( spawnMaxVar );
		waveState = 1;
	}
}
