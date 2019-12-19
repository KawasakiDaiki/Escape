using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DamageEffector : MonoBehaviour
{
    [SerializeField] PostProcessVolume damageEffectVolume;
    [SerializeField] AnimationCurve effectCurve;
    [SerializeField, Tooltip("エフェクトにかける時間")] float effectTime;

    /// <summary>
    /// ダメージエフェクトを再生する
    /// </summary>
    public void PlayEffect()
    {
        StartCoroutine(EffectCoroutine());
    }

    IEnumerator EffectCoroutine()
    {
        float time = 0;
        while (true)
        {
            damageEffectVolume.weight = effectCurve.Evaluate(time / effectTime);
            if (time > effectTime)
            {
                break;
            }
            time += Time.deltaTime;
            yield return null;
        }
    }
}
