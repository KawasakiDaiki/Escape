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
    Color[] colors =
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.black
    };
    [SerializeField]GameObject itemPrefav;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }



    //ボタン入力されたらアイテムをインスタンス、ボタンごとにタイプ分け
    public void OnClick(int type)
    {
        //プレイヤーの足元に生成
        Vector3 footPos = player.transform.position - player.transform.up * 0.5f;
        GameObject item = Instantiate(itemPrefav, footPos, Quaternion.identity);
        item.GetComponent<ItemType>().type = (Types)type;
        item.GetComponent<MeshRenderer>().material.color = colors[type];
    }
}
