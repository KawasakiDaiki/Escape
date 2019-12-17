using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGenerater : MonoBehaviour
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
    private GameObject[] tagObjects;//tag_nameの名前をもつタグのオブジェクトを入れる配列
    private ObjectPool _pool;
    private int start_x,start_y;//生成座標代入
    private float time;
    private Transform _tf;

   private void Start()
    {
        _pool = GameObject.Find(objpool).GetComponent<ObjectPool>();
    }

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
        if (time > pop_start&& Time.timeScale!=0)
        {
            tagObjects = GameObject.FindGameObjectsWithTag(tag_name);
            if (tagObjects.Length < _pool.maxcount)
            {
                var objects = _pool.GetObject();
                //ランダムに再配置
                start_x = (int)Random.Range(-GenbereteRangeRestriction, GenbereteRangeRestriction);
                start_y = (int)Random.Range(-GenbereteRangeRestriction, GenbereteRangeRestriction);
                objects.transform.position = new Vector3(start_x, start_y, 0);
            }
        }
    }
}
