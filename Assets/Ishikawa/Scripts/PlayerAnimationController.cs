using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private static readonly string ScatterKey = "Scatter";
    private static readonly string RunKey = "Run";
    Animator animator;

    public bool IsScattering { get; set; }

    [SerializeField] ItemManeger itemManager;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// 走るアニメーションを再生する
    /// </summary>
    public void PlayRun()
    {
        animator.SetBool(RunKey, true);
    }

    /// <summary>
    /// 走るアニメーションを止める
    /// </summary>
    public void StopRun()
    {
        animator.SetBool(RunKey, false);
    }

    /// <summary>
    /// 撒くアニメーションを再生する
    /// </summary>
    public void PlayScatter(int type)
    {
        if (!IsScattering)
        {
            IsScattering = true;
            animator.SetTrigger(ScatterKey + type.ToString());
        }
    }

    /// <summary>
    /// 実際に撒く
    /// </summary>
    public void Scatter(int type)
    {
        itemManager.OnClick(type);
        AudioManager.Instance.PlayScatterSE(type);
        IsScattering = false;
    }
}
