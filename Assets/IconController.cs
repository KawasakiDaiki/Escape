using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconController : MonoBehaviour
{

	GameObject enemyobject;
	[SerializeField] GameObject playerPos;
	bool imageEnable = false;

    void Start()
    {
		//Debug.Log( enemyobject.name );

		//RectTransform pos = GetComponent<RectTransform>();
		//pos.anchoredPosition = new Vector2( 400 * side, 700 );
		//playerPos = GameObject.FindGameObjectWithTag( "Player" );
		//gameObject.SetActive( true );
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyobject)
        {
            Vector3 pPos = playerPos.GetComponent<Transform>().position;
            Vector3 ePos = enemyobject.GetComponent<Transform>().position;
            float distance = Vector3.SqrMagnitude(pPos - ePos);

            float size = 150.0f + (200.0f - distance);

            GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
        }
        else
        {
			
        }
        //Debug.Log( distance );

    }

	public void GetEnemyObject( GameObject enemy, bool imageFlg )
	{
		enemyobject = enemy;
		imageEnable = imageFlg;
	}
}
