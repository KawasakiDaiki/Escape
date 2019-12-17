﻿using UnityEngine;

public class IconController : MonoBehaviour
{

    GameObject enemyobject;
    GameObject playerPos;
    int side = 0;

    void Start()
    {
        Debug.Log(enemyobject.name);

        RectTransform pos = GetComponent<RectTransform>();
        pos.anchoredPosition = new Vector2(500 * side, 500);
        playerPos = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyobject)
        {
            Vector3 pPos = playerPos.GetComponent<Transform>().position;
            Vector3 ePos = enemyobject.GetComponent<Transform>().position;
            float distance = Vector3.Distance(pPos, ePos);

            float size = 50.0f + 200.0f * (1 - distance / 50.0f);

            GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
        }
        else
        {
            Destroy(gameObject);
        }
        //Debug.Log( distance );

    }

    public void GetEnemyObject(GameObject enemy, int spawnSide)
    {
        enemyobject = enemy;
        side = spawnSide;
    }
}
