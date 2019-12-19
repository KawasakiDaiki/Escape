using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource SESource;

    [SerializeField] AudioClip[] SEClips;

    enum SEClipName
    {
    }
    void Awake()
    {
        CheckInstance();
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
    }

    public void PlaySE()
    {
        SESource.PlayOneShot(SESource.clip);
    }
}
