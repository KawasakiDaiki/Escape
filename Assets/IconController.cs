using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconController : MonoBehaviour
{

	GameObject enemyobject;
	int side = 0;

    void Start( )
    {
		Debug.Log( enemyobject.name );

		RectTransform pos = GetComponent<RectTransform>();

		pos.anchoredPosition = new Vector2( 120 * side, 140 );
    }

    // Update is called once per frame
    void Update()
    {
    }

	public void GetEnemyObject( GameObject enemy, int spawnSide )
	{

		enemyobject = enemy;
		side = spawnSide;
	}
}
