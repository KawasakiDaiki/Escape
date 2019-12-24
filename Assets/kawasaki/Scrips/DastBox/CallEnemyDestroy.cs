/*
 2019/12/19
 制作：川崎大樹
 Enemyの死亡処理サンプル
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEnemyDestroy : MonoBehaviour
{
    /// <summary>
    /// 敵の死亡アニメーション
    /// </summary>
    /// <remarks>
    /// アイテムと当たったらアイテム側からコール
    /// </remarks>
    public void DesEfectMove()
    {
        GetComponent<Animator>().SetTrigger(0);
    }

    /// <summary>
    /// アニメーション後に破壊する用
    /// </summary>
    void DestroyEvent()
    {
        Destroy(this.gameObject);
    }
    void clamp()
    {
        float a = Mathf.Max(-100, 0);

    }
}
