using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    GameObject _poolObj; // プールするオブジェクト。
    [SerializeField]
    internal int maxcount; // 最初に生成するオブジェクトの湧き数制限となる
    private List<GameObject> _poolObjList; // 生成したオブジェクトのリスト。このリストの中から未使用のものを探したりする 

    void Awake()
    {
        CreatePool();
    }

    // 最初にある程度の数、オブジェクトを作成してプールしておく処理
    private void CreatePool()
    {
        _poolObjList = new List<GameObject>();
        for (int i = 0; i < maxcount; i++)
        {
            var newObj = CreateNewObject(); // オブジェクトを生成して
            newObj.SetActive(false); // 物理演算を切って(=未使用にして)
            _poolObjList.Add(newObj); // リストに保存しておく
        }
    }

    // 未使用のオブジェクトを探して返す処理
    // 未使用のものがなければ新しく作って返す
    public GameObject GetObject()
    {
        // 使用中でないものを探して返す
         foreach (var obj in _poolObjList)
         {
             if (obj.activeSelf == false)
             {
                 obj.SetActive(true);
                 return obj;
             }
         }

        // 全て使用中だったら新しく作り、リストに追加してから返す
         var newObj = CreateNewObject();
         _poolObjList.Add(newObj);
         return newObj;
     }

     // 新しくオブジェクトを作成する処理
     private GameObject CreateNewObject()
     {
         var pos = new Vector2(100, 100); // 画面外であればどこでもOK
         var newObj = Instantiate(_poolObj, pos, Quaternion.identity); // オブジェクトを生成しておいて
         newObj.name = _poolObj.name + (_poolObjList.Count + 1); // 名前を連番でつけてから
         return newObj; // 返す
     }
     public int GenerateRestriction()
     {
         return maxcount;
     }
}