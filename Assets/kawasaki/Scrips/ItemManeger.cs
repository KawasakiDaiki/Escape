/*
 2019/12/17
 作成：川崎大樹
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class ItemManeger : MonoBehaviour
{
    // パーティクルを格納
    [SerializeField,Tooltip("0:salt/1:money")] GameObject[] Particles;

    // アイテムの種類
    public enum Types
    {
        salt,
        money,
        boss,

        TypeNum,
    }

    [SerializeField]GameObject ItemPrefav;
    List<GameObject> itemPool = new List<GameObject>();
    int poolCount = 10;

    [SerializeField] GameObject player;



    void Start()
    {
        //アイテムをpool
        for(int i = 0; i < poolCount; i++)
        {
            itemPool.Add(Instantiate(ItemPrefav,new Vector3(100,100,100),Quaternion.identity));
            itemPool[i].SetActive(false);
            itemPool[i].transform.SetParent(transform);
        }
    }



    //ボタン入力
    public void OnClick(int type)
    {
        //poolから使えるのがあれば使用
        int i = 0;
        for (; i < poolCount; i++)
        {
            if (!itemPool[i].activeSelf)
            {
                ItemCreator(type, itemPool[i]);
                return;
            }
        }
        OverPool(type);
    }

    //使えるものがないとき
    void OverPool(int type)
    {
        //生成してpoolに追加
        itemPool.Add(Instantiate(ItemPrefav, new Vector3(100, 100, 100), Quaternion.identity));
        poolCount = itemPool.Count;
        itemPool[poolCount - 1].transform.SetParent(transform);
        ItemCreator(type, itemPool[poolCount - 1]);
    }

    //使えるものがある時
    public void ItemCreator(int type, GameObject itemObj)
    {
        Vector3 footPos =player.transform.parent.transform.position;
        footPos.x += player.GetComponent<PlayerHorizontalMover>().CurrentLine;

        //プレイヤー座標に生成
        itemObj.transform.position = footPos;
        itemObj.SetActive(true);

        footPos.y = 0;
        //パーティクル生成
        Instantiate(Particles[type], footPos, Particles[type].transform.rotation);

        //type設定
        itemObj.GetComponent<ItemType>().type = (Types)type;
		Debug.Log( itemObj.GetComponent<ItemType>().type );
        itemObj.GetComponent<ItemType>().StartCol();
    }

    //エネミーから呼ばれるとpoolにオブジェクトを返す
    public static void ReturnPool(GameObject seed)
    {
        seed.SetActive(false);
        seed.transform.position = new Vector3(100, 100, 100);
    }
}
