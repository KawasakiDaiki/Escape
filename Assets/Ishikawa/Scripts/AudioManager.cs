using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource SESource;

    [SerializeField, Tooltip("撒くSEのクリップ")] AudioClip[] scatterClips;
    [SerializeField, Tooltip("出現SEのクリップ")] AudioClip[] bornClips;
    [SerializeField, Tooltip("出現SEのクリップ")] AudioClip[] disappearClips;

    void Awake()
    {
        CheckInstance();
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
    }

    /// <summary>
    /// 撒く音再生する。0:塩, 1:お金
    /// </summary>
    public void PlayScatterSE(int type)
    {
        SESource.PlayOneShot(scatterClips[type]);
    }

    /// <summary>
    /// 出現音再生 0:ghost, 1:drunkman, 2:believer
    /// </summary>
    /// <param name="type"></param>
    public void PlayBornSE(int type)
    {
        SESource.PlayOneShot(bornClips[type]);
    }

    /// <summary>
    /// 撃退音再生
    /// </summary>
    /// <param name="type"></param>
    public void PlayDisappearSE(int type)
    {
        SESource.PlayOneShot(disappearClips[type]);
    }
}
