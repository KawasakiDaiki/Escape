/*
 2019/12/17
 作成：川崎大樹
カメラ移動の地点を保持
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : SingletonMonoBehaviour<CameraManager>
{
    [SerializeField] private GameObject PlayerObject;
    [SerializeField,Range(0.01f,1.0f)] private float RecastTime=0.1f;
    List<Vector3> playerFootprint = new List<Vector3>();

    void Start()
    {
        InGameScene();
    }


    /// <summary>
    /// 一定時間毎にプレイヤーポジションを保存
    /// </summary>
    /// <returns>
    /// 
    /// </returns>
    IEnumerator PlayerPosGeter(GameObject player)
    {
        while (GameManager.Instance.State==GameState.InGame)
        {
            Vector3 pos = player.transform.position;
            if (pos == playerFootprint[playerFootprint.Count - 1]) continue;
            playerFootprint.Add(player.transform.position);
            yield return new WaitForSeconds(RecastTime);
        }
        playerFootprint.Clear();
    }

    public void InGameScene()
    {
        StartCoroutine(PlayerPosGeter(PlayerObject));
    }


    /// <summary>
    /// 次の地点を取得
    /// </summary>
    /// <returns>
    /// 地点がない場合はnullを返す
    /// nullチェックしてVector3にキャストして使用してください
    /// </returns>
    public Vector3? GetNextPosition()
    {
        if (playerFootprint.Count <= 0) return null;


        Vector3 pos = playerFootprint[0];
        playerFootprint.RemoveAt(0);
        return pos;
    }
}
