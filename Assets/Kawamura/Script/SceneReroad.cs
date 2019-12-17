using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReroad : MonoBehaviour
{
    [SerializeField]
    private float _TimerLimit;
    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;
    }
    private void TitleSceneTimer()
    {
        
        if(_time > _TimerLimit && Time.timeScale != 0)
            {
            TitleScene();
            }
    }
    private void TitleScene()
    {
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(loadScene.name);

    }
}
