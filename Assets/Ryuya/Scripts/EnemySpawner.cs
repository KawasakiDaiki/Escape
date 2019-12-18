using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] bool debugMode;

	[SerializeField] GameObject[] enemy;
	[SerializeField] GameObject player;

	[SerializeField] GameObject canvas;
	//[SerializeField] GameObject[] enemyIcon;

	// Canvas/Imageの名前をあらかじめ入れておく変数
	[SerializeField] string[] imageNameLeft;
	[SerializeField] string[] imageNameCenter;
	[SerializeField] string[] imageNameRight;

	//ゲームオブジェクトのリスト(レーン順)
	private List<GameObject> enemyListLeft = new List<GameObject>();
	private List<GameObject> enemyListCenter = new List<GameObject>();
	private List<GameObject> enemyListRight = new List<GameObject>();

	// AddList時に使う変数
	private int listR = 0;
	private int listC = 0;
	private int listL = 0;

	//待機時間などはフレームで管理しています。

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

	IEnumerator routine;
	bool spawnFlg = false;

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
			Transform playerPos = player.GetComponent<Transform>();
			float spawnX = playerPos.position.x - ( -playerPos.forward.x * distance ) + ( playerPos.right.x * spawnSide );
			float spawnY = playerPos.position.y;
			float spawnZ = playerPos.position.z - ( -playerPos.forward.z * distance ) + ( playerPos.right.z * spawnSide );
			GameObject instantiateEnemy = Instantiate( enemy[ enemyNumber ], 
														new Vector3( spawnX, spawnY, spawnZ ), 
														player.transform.rotation );

			//if( spawnSide == -1 )
			//{
			//	enemyListLeft.Add( instantiateEnemy );
			//	Debug.Log( "trueL" );
			//	GameObject eIcon = GameObject.Find( imageNameLeft[ listL ] );
			//	eIcon.GetComponent<Image>().enabled = true;
			//	Debug.Log( eIcon.name );
			//	IconController objectPass = eIcon.GetComponent<IconController>();
			//	objectPass.GetEnemyObject( instantiateEnemy, true );
			//	if( listL++ > 2 )
			//	{
			//		listL = 0;
			//	}
			//}
			//else if( spawnSide == 0 )
			//{
			//	enemyListCenter.Add( instantiateEnemy );
			//	Debug.Log( "trueC" );

			//	GameObject eIcon = GameObject.Find( imageNameCenter[ listC ] );
			//	eIcon.GetComponent<Image>().enabled = true;

			//	Debug.Log( eIcon.name );

			//	IconController objectPass = eIcon.GetComponent<IconController>();
			//	objectPass.GetEnemyObject( instantiateEnemy, true );

			//	if( listL++ > 2 )
			//	{
			//		listL = 0;
			//	}
			//}
			//else if( spawnSide == 1 )
			//{
			//	enemyListRight.Add( instantiateEnemy );
			//	Debug.Log( "trueR" );
			//	GameObject eIcon = GameObject.Find( imageNameRight[ listR ] );
			//	eIcon.GetComponent<Image>().enabled = true;
			//	Debug.Log( eIcon.name );
			//	IconController objectPass = eIcon.GetComponent<IconController>();
			//	objectPass.GetEnemyObject( instantiateEnemy, true );
			//	if( listL++ > 2 )
			//	{
			//		listL = 0;
			//	}
			//}

			EnemyInit();

		}
	}

	//時間、スポーンする敵、スポーンするサイドを変える初期処理のようなもの
	void EnemyInit()
	{
		waitTime = waitState;
		randomTime = Random.Range( 6f, 7f );
		waitTime += randomTime;
		enemyNumber = Random.Range( 0, enemyTypeVar );
		spawnSide = Random.Range( -1, 2 );
	}
}
