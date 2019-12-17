using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManeger : MonoBehaviour
{
    //アイテムの種類
    public enum Types
    {
        bean,
        money,
        salt,
        seed,

        TypeNum,
    }
    //デバッグ用に色変更
    public static Color[] colors =
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.black
    };
    [SerializeField]GameObject itemPrefav;
    List<GameObject> ItemPool = new List<GameObject>();
    int poolCount = 10;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        for(int i = 0; i < poolCount; i++)
        {
            ItemPool.Add(Instantiate(itemPrefav));
            ItemPool[i].SetActive(false);
            ItemPool[i].transform.SetParent(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }



    //ボタン入力されたらアイテムをインスタンス、ボタンごとにタイプ分け
    public void OnClick(int type)
    {
        int i = 0;
        for (; i < poolCount; i++)
        {
            Debug.Log("a");

            if (!ItemPool[i].activeSelf)
            {
                player.GetComponent<PlayerWideMove>().ItemCreator(type, ItemPool[i]);
                return;
            }
        }
        ItemPool.Add(Instantiate(itemPrefav));
        poolCount = ItemPool.Count;
        ItemPool[poolCount-1].transform.SetParent(transform);
        player.GetComponent<PlayerWideMove>().ItemCreator(type, ItemPool[poolCount - 1]);

    }
}
