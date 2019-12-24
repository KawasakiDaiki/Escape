/*
 2019/12/17
 作成：川崎大樹
 */

using Player;
using System.Collections.Generic;
using UnityEngine;

public class ItemManeger : MonoBehaviour
{
    // アイテムの種類
    public enum Types
    {
        salt,//塩
        money,//お金

        TypeNum,//アイテムの種類
    }

    // パーティクルを格納
    [SerializeField, Tooltip("0:salt/1:money")] GameObject[] Particles;

    [SerializeField] GameObject ItemPrefav;

    //アイテムの格納リストと個数
    List<GameObject> itemPool = new List<GameObject>();

    [SerializeField] GameObject player;



    void Start()
    {
        //アイテムをpool
        for (int i = 0; i < 10; i++)
        {
            itemPool.Add(Instantiate(ItemPrefav, new Vector3(100, 100, 100), Quaternion.identity));
            itemPool[i].SetActive(false);
            itemPool[i].transform.SetParent(transform);
        }
    }



    //ボタン入力
    public void OnClick(int type)
    {
        //poolから使えるのが
        
        int i = 0;
        for (; i < itemPool.Count; i++)
        {
            if (!itemPool[i].activeSelf)
            {
                //ある
                ItemCreator(type, itemPool[i]);
                return;
            }
        }
        //ない
        OverPool(type);
    }

    //使えるものがない時
    void OverPool(int type)
    {
        //生成してpoolに追加
        itemPool.Add(Instantiate(ItemPrefav, new Vector3(100, 100, 100), Quaternion.identity));
        itemPool[itemPool.Count - 1].transform.SetParent(transform);
        ItemCreator(type, itemPool[itemPool.Count - 1]);
    }

    //使えるものがある時
    public void ItemCreator(int type, GameObject itemObj)
    {
        Vector3 footPos = Vector3.zero;
        footPos.x += player.GetComponent<PlayerHorizontalMover>().CurrentLine;

        //プレイヤー座標に生成
        itemObj.transform.position = footPos;
        itemObj.SetActive(true);

        footPos.y = 0;
        //パーティクル生成
        Instantiate(Particles[type], footPos + Vector3.right * 0.3f, Particles[type].transform.rotation);

        //type設定
        itemObj.GetComponent<ItemType>().type = (Types)type;
    }

    //エネミーから呼ばれるとpoolにオブジェクトを返す
    public static void ReturnPool(GameObject seed)
    {
        seed.SetActive(false);
        seed.transform.position = new Vector3(100, 100, 100);
    }
}