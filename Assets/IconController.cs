using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconController : MonoBehaviour
{

	GameObject enemyobject;
	GameObject playerPos;
	int side = 0;

    void Start()
    {
		Debug.Log( enemyobject.name );

		RectTransform pos = GetComponent<RectTransform>();
		pos.anchoredPosition = new Vector2( 120 * side, 180 );
		playerPos = GameObject.FindGameObjectWithTag( "Player" );
    }

    // Update is called once per frame
    void Update()
    {

		Vector3 pPos = playerPos.GetComponent<Transform>().position;
		Vector3 ePos = enemyobject.GetComponent<Transform>().position;
		float distance = Vector3.SqrMagnitude( pPos - ePos );

		float size = 50.0f + ( 100.0f - distance );

		GetComponent<RectTransform>().sizeDelta = new Vector2( size, size );

		//Debug.Log( distance );

    }

	public void GetEnemyObject( GameObject enemy, int spawnSide )
	{
		enemyobject = enemy;
		side = spawnSide;
	}
}
