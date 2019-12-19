using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// フリックの方向の列挙体
/// </summary>
public enum FlickDirection
{
    Right = 1,
    None = 0,
    Left = -1
}

/// <summary>
/// フリック入力を取るクラス
/// </summary>
public class FlickInput : MonoBehaviour
{
    [SerializeField, Tooltip("フリック判定する最低の速さ")]
    private float minSpeed = 20;
    [SerializeField, Tooltip("左右の検出可能な角度"), Range(0, 180.0f)]
    private float detectionAngle = 90;

    private Vector3 previousPosition;

    // 現フレーム、前フレームの状態
    private FlickDirection flickState;
    private FlickDirection previousFlickState;

    // 定数
    static readonly float RightAngle = 90.0f;
    static readonly float LeftAngle = -90.0f;

    void Update()
    {
        // 前フレームの状態を記録
        previousFlickState = flickState;

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                previousPosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {

                // 1フレームの移動量
                Vector3 deltaDistance = Input.mousePosition - previousPosition;
                previousPosition = Input.mousePosition;
                if (deltaDistance.sqrMagnitude > minSpeed * minSpeed)
                {
                    float angle = Mathf.Atan2(deltaDistance.x, deltaDistance.y) * Mathf.Rad2Deg;
                    if ((RightAngle - detectionAngle / 2) < angle && angle < (RightAngle + detectionAngle / 2))
                    {
                        flickState = FlickDirection.Right;
                    }
                    if ((LeftAngle - detectionAngle / 2) < angle && angle < (LeftAngle + detectionAngle / 2))
                    {
                        flickState = FlickDirection.Left;
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                flickState = FlickDirection.None;
            }
        }
    }

    /// <summary>
    /// <para>フリックされた瞬間を検知する</para>
    /// <example>例)左にフリック:
    /// <code>
    /// if (GetFlick(FlickDirection.Left))
    /// {
    ///     // Do anything.
    /// }
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="direction">フリックの方向</param>
    public bool GetFlick(FlickDirection direction)
    {
        return previousFlickState != direction && flickState == direction;
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        // 検出角度のギズモ表示
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(Mathf.Sin((RightAngle - detectionAngle / 2) * Mathf.Deg2Rad), Mathf.Cos((RightAngle - detectionAngle / 2) * Mathf.Deg2Rad)));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(Mathf.Sin((RightAngle + detectionAngle / 2) * Mathf.Deg2Rad), Mathf.Cos((RightAngle + detectionAngle / 2) * Mathf.Deg2Rad)));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(Mathf.Sin((LeftAngle - detectionAngle / 2) * Mathf.Deg2Rad), Mathf.Cos((LeftAngle - detectionAngle / 2) * Mathf.Deg2Rad)));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(Mathf.Sin((LeftAngle + detectionAngle / 2) * Mathf.Deg2Rad), Mathf.Cos((LeftAngle + detectionAngle / 2) * Mathf.Deg2Rad)));
    }
#endif
}
