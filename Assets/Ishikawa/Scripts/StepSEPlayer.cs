using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StepSEPlayer : MonoBehaviour
{
    [SerializeField] float minPitch;
    [SerializeField] float maxPitch;
    AudioSource stepSource;
    void Start()
    {
        stepSource = GetComponent<AudioSource>();
    }

    public void PlayStepSE()
    {
        stepSource.pitch = Random.Range(1.5f, 2f);
        stepSource.PlayOneShot(stepSource.clip);
    }
}
