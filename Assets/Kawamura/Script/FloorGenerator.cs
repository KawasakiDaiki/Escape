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
        float _pop_start =0; //生成を始める時間
    [SerializeField]
    private float _Floor_z;　//床プレハブの長さ
    [SerializeField]
    private int _rePopTime;　//再生成までの秒数
    private float _rePopCheck;//再生成までの時間がたったかの確認
    private float _rePopTimebox;//_rePopCheckの借り入れ
    private float _Start_z = 0;//床プレハブ1つの長さ
    private GameObject[] tagObjects;//tag_nameの名前をもつタグのオブジェクトを入れる配列
    private ObjectPool _pool;

   
    private float _time;
    private Transform _tf;

   private void Start()
    {
        _pool = GameObject.Find(_objpool).GetComponent<ObjectPool>();
        _rePopTimebox = _rePopTime;
    }

    private void Update()
    {
        _rePopCheck =  Time.deltaTime % _rePopTime;
        _time += Time.deltaTime; //シーンが起動されてからどれくらいの時間でオブジェクトが沸くか
        if (_time > _pop_start&& Time.timeScale!=0)
        {
            tagObjects = GameObject.FindGameObjectsWithTag(_tag_name);
            if (tagObjects.Length < _pool._maxcount)
            {
                 
                 var objects = _pool.GetObject();
                 //床の継ぎ足し
                 objects.transform.position = new Vector3(0, 0, _Start_z);
                 _Start_z += _Floor_z;
                
            }
        }
    }
}
