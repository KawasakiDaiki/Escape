using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
	//敵のオブジェクト
	[SerializeField] GameObject[] enemy;

	//プレイヤーのオブジェクト
	[SerializeField] GameObject player;

	//基本となる待機時間の変数。そのうちこちらもタイミング変更で変えていきます。
	private float waitState = 3.0f;
	//実際に使用する(減算する)変数
	private float waitTime = 3.0f;
	//ランダムな時間を代入する変数
	private float randomTime = 0f;      


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

	int spawnMaxVar = 3;
	int spawnVar = 1;
	int multiSpawnWaitTime = 3;

	// Start is called before the first frame update
	void Start()
	{
		EnemyInit();
	}

	// Update is called once per frame
	void Update()
	{
		waitTime -= 0.01f;

		if( waitTime <= -0.0f )
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
				EnemyInit();
				if( multiSpawnWaitTime >= 3 )
				{
					spawnVar = Random.Range( 1, spawnMaxVar + 1 );
					//multiSpawnWaitTime = 3;
					multiSpawnWaitTime++;
					if( spawnVar >= 2 )
					{
						multiSpawnWaitTime = 3;
					}
				}
			}

		}
	}

	//時間、スポーンする敵、スポーンするサイドを変える初期処理のようなもの
	void EnemyInit()
	{
		waitTime = waitState;
		randomTime = Random.Range( 0f, 4f );
		waitTime += randomTime;
		enemyNumber = Random.Range( 0, enemyTypeVar );
		spawnSide = Random.Range( -1, 2 );
	}
}
