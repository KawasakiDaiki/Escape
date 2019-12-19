/*
 2019/12/19
 作成：川崎大樹
 一時的Moveベース
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveBase : MonoBehaviour
{
    //世界の移動スピード(正)
    protected float BaseSpeed = 10;

    //移動処理
    public abstract void Move();

    //死亡処理
    public virtual void CallDesEffect(){}

    //トリガー当たり判定
    public virtual void OnTriggerEnter(Collider col){}

}
