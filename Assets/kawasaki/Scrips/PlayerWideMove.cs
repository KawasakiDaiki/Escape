﻿/*
 2019/12/16
 作成：川崎大樹
 プレイヤー横方向への移動
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWideMove : MonoBehaviour
{
    private int NowLine = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WideMove();
    }
    void WideMove()
    {
        if (Input.GetKeyDown(KeyCode.A) && NowLine > -1)
        {
            transform.position -= transform.right;
            NowLine--;
        }
        if (Input.GetKeyDown(KeyCode.D) && NowLine < 1)
        {
            transform.position += transform.right;
            NowLine++;
        }
    }
    public void ItemCreator(int type,GameObject obj)
    {
        //プレイヤーの足元に生成
        Vector3 footPos = transform.position /*- transform.up * 0.5f*/;
        obj.transform.position = footPos;
        obj.SetActive(true);
        obj.GetComponent<ItemType>().type = (ItemManeger.Types)type;
        obj.GetComponent<MeshRenderer>().material.color = ItemManeger.colors[type];
    }
}
