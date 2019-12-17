/*
   2019/12/16
   河村竜樹
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerater : MonoBehaviour
{
    [SerializeField]
        GameObject objectsPrefab;//沸かせるものの情報
    //[SerializeField] int objectsGenerateRestriction;//沸き数制限
    [SerializeField]
        string tag_name;//タグ名を入れる
    [SerializeField]
        string objpool;//オブジェクトプール化するオブジェクト名
    [SerializeField]
        float pop_start;

    private float start_z = 0;//床1つの長さ
    private GameObject[] tagObjects;//tag_nameの名前をもつタグのオブジェクトを入れる配列
    private ObjectPool _pool;
    
    private float time;
    private Transform _tf;

   private void Start()
    {
        _pool = GameObject.Find(objpool).GetComponent<ObjectPool>();
    }

    private void Update()
    {
        time += Time.deltaTime; //シーンが起動されてからどれくらいの時間でオブジェクトが沸くか
        if (time > pop_start&& Time.timeScale!=0)
        {
            tagObjects = GameObject.FindGameObjectsWithTag(tag_name);
            if (tagObjects.Length < _pool.maxcount)//最大数まで生成
            {
                var objects = _pool.GetObject();
                //床の継ぎ足し
                objects.transform.position = new Vector3(0, 0, start_z);
                start_z += start_z;
            }
        }
    }
}
