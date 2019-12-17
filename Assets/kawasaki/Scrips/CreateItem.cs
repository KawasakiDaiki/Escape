using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    public enum Types
    {
        bean,
        money,
        salt,
        seed,

        TypeNum,
    }
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

    public void OnClick(int type)
    {
        GameObject item = Instantiate(itemPrefav, player.transform.position-player.transform.up*0.5f, Quaternion.identity);
        item.GetComponent<MeshRenderer>().material.color = colors[type];
        item.GetComponent<ItemType>().type = (Types)type;
    }
}
