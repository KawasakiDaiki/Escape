using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{

    // 実体を格納するための変数
    private static T instance;

    // プロパティ
    public static T Instance
    {
        get
        {
            // 初回のアクセスではinstanceは空なので、シーン上から検索し格納して返す。以降は格納されたものをそのまま返す。
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    Debug.LogError(typeof(T) + "をアタッチしているGameObjectはありません");
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        CheckInstance();
    }

    /// <summary>
    /// インスタンスが重複していたら削除する。
    /// </summary>
    protected void CheckInstance()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
        }
    }
}
