using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject[] enemy;
    [SerializeField] GameObject player;
    //[SerializeField] RectTransform rect;

    [SerializeField] GameObject canvas;
    [SerializeField] GameObject[] enemyIcon;

    //待機時間などはフレームで管理しています。

    //基本となる待機時間の変数。そのうちこちらもタイミング変更で変えていきます。
    private float waitState = 1.0f;
    //実際に使用する(減算する)変数
    private float waitTime = 3.0f;
    //ランダムな時間を代入する変数
    private float randomTime = 0f;


    //ランダムで敵の種類を決める変数
    private int enemyNumber = 0;
    //スポーンする位置を変える変数
    private int spawnSide = 0;

    //UIのサイズ定数
    const float uiSizeX = 100;
    const float uiSizeY = 100;
    //UIのサイズを変える変数
    private float uiSizeMove = 0;




    // Start is called before the first frame update
    void Start()
    {
        EnemyInit();
    }

    // Update is called once per frame
    void Update()
    {
        //uiSizeMove += 0.1f;
        //rect.sizeDelta = new Vector2( uiSizeX + uiSizeMove, uiSizeY + uiSizeMove );
        waitTime -= 0.01f;
        //Debug.Log( WaitTime );
        if (waitTime <= -0.0f)
        {
            Transform playerPos = player.GetComponent<Transform>();
            float spawnX = playerPos.position.x - (playerPos.forward.x * 10) + (playerPos.right.x * spawnSide);
            //Debug.Log( spawnSide );
            float spawnY = playerPos.position.y;
            float spawnZ = playerPos.position.z - (playerPos.forward.z * 30) + (playerPos.right.z * spawnSide);
            GameObject instantiateEnemy = Instantiate(enemy[enemyNumber], new Vector3(spawnX, spawnY, spawnZ), player.transform.rotation);

            GameObject eIcon = (GameObject)Instantiate(enemyIcon[enemyNumber]);
            eIcon.transform.SetParent(canvas.transform, false);
            IconController objectPass = eIcon.GetComponent<IconController>();
            //Debug.Log( objectPass );
            objectPass.GetEnemyObject(instantiateEnemy, spawnSide);

            EnemyInit();
        }
    }

    //時間、スポーンする敵、スポーンするサイドを変える初期処理のようなもの
    void EnemyInit()
    {
        waitTime = waitState;
        randomTime = Random.Range(0f, 3f);
        waitTime += randomTime;
        enemyNumber = Random.Range(1, 4);
        spawnSide = Random.Range(-1, 2);
    }
}
