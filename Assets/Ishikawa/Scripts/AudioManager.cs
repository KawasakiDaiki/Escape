using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource SESource;

    [SerializeField, Tooltip("撒くSEのクリップ")] AudioClip[] scatterClips;

    void Awake()
    {
        CheckInstance();
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
    }

    /// <summary>
    /// 撒く再生する。0:塩, 1:お金
    /// </summary>
    public void PlayScatterSE(int type)
    {
        SESource.PlayOneShot(scatterClips[type]);
    }

}
