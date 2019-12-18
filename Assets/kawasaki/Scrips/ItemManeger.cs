using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class ItemManeger : MonoBehaviour
{
    //アイテムの種類
    public enum Types
    {
        money,
        salt,

        TypeNum,
    }
    //デバッグ用に色変更
    public static Color[] colors =
    {
        Color.yellow,
        Color.white,
    };

    [SerializeField]GameObject itemPrefav;
    List<GameObject> ItemPool = new List<GameObject>();
    int poolCount = 10;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        //アイテムをpool
        for(int i = 0; i < poolCount; i++)
        {
            ItemPool.Add(Instantiate(itemPrefav,new Vector3(100,100,100),Quaternion.identity));
            ItemPool[i].SetActive(false);
            ItemPool[i].transform.SetParent(transform);
        }
    }



    //ボタン入力されたらアイテムをインスタンス、ボタンごとにタイプ分け
    public void OnClick(int type)
    {
        //poolから使えるのがあれば使用
        int i = 0;
        for (; i < poolCount; i++)
        {
            Debug.Log("a");

            if (!ItemPool[i].activeSelf)
            {
                StartCoroutine(ItemCreator(type, ItemPool[i]));
                return;
            }
        }
        //なければ生成してpoolに追加
        ItemPool.Add(Instantiate(itemPrefav,new Vector3(100,100,100),Quaternion.identity));
        poolCount = ItemPool.Count;
        ItemPool[poolCount-1].transform.SetParent(transform);
        StartCoroutine(ItemCreator(type, ItemPool[poolCount - 1]));

    }

    public IEnumerator ItemCreator(int type, GameObject obj)
    {
        while (true)
        {
            if (!player.GetComponent<PlayerHorizontalMover>().IsMoving)break;
            yield return null;
        }
        //プレイヤーの足元に生成
        Vector3 footPos =player.transform.position /*- transform.up * 0.5f*/;
        obj.transform.position = footPos;
        obj.SetActive(true);


        obj.GetComponent<ItemType>().type = (Types)type;
        obj.GetComponent<MeshRenderer>().material.color = colors[type];
    }
}
