/*
   2019/12/16
   河村竜樹
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    [SerializeField]
        GameObject _objectsPrefab;//沸かせるものの情報
    //[SerializeField] int objectsGenerateRestriction;//沸き数制限
    [SerializeField]
        string _tag_name;//タグ名を入れる
    [SerializeField]
        string _objpool;//オブジェクトプール化するオブジェクト名
    [SerializeField]
        float _pop_start =0;
    [SerializeField]
    private float _Floor_z;
    private float _Start_z = 0;//床プレハブ1つの長さ
    private GameObject[] tagObjects;//tag_nameの名前をもつタグのオブジェクトを入れる配列
    private ObjectPool _pool;
    
    private float _time;
    private Transform _tf;

   private void Start()
    {
        _pool = GameObject.Find(_objpool).GetComponent<ObjectPool>();
    }

    private void Update()
    {
        _time += Time.deltaTime; //シーンが起動されてからどれくらいの時間でオブジェクトが沸くか
        if (_time > _pop_start&& Time.timeScale!=0)
        {
            tagObjects = GameObject.FindGameObjectsWithTag(_tag_name);
            if (tagObjects.Length < _pool.maxcount)
            {
                var objects = _pool.GetObject();

                //床の継ぎ足し
                objects.transform.position = new Vector3(0, (float)-1.5, _Start_z);
                _Start_z += _Floor_z;
            }
        }
    }
}
