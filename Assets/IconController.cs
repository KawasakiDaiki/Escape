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
