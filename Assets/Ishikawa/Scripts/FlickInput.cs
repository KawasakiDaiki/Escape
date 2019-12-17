using UnityEngine;

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
    [SerializeField, Tooltip("フリック判定する最低の速さ")] float minSpeed;
    [SerializeField, Tooltip("左右の判定を取る角度"), Range(0, 180.0f)] float detectionAngle;

    Vector3 previousPosition;

    FlickDirection flickState;
    FlickDirection previousFlickState;

    static readonly float RightAngle = 90.0f;
    static readonly float LeftAngle = -90.0f;


    void Update()
    {
        // 前フレームの状態を記録
        previousFlickState = flickState;

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

        if (GetFlick(FlickDirection.Left))
        {
            Debug.Log("Left");
        }
        if (GetFlick(FlickDirection.Right))
        {
            Debug.Log("Right");
        }
    }

    /// <summary>
    /// フリックされた瞬間を検知する
    /// </summary>
    /// <param name="direction">フリックの方向</param>
    public bool GetFlick(FlickDirection direction)
    {
        return previousFlickState != direction && flickState == direction;
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(Mathf.Sin((RightAngle - detectionAngle / 2) * Mathf.Deg2Rad), Mathf.Cos((RightAngle - detectionAngle / 2) * Mathf.Deg2Rad)));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(Mathf.Sin((RightAngle + detectionAngle / 2) * Mathf.Deg2Rad), Mathf.Cos((RightAngle + detectionAngle / 2) * Mathf.Deg2Rad)));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(Mathf.Sin((LeftAngle - detectionAngle / 2) * Mathf.Deg2Rad), Mathf.Cos((LeftAngle - detectionAngle / 2) * Mathf.Deg2Rad)));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(Mathf.Sin((LeftAngle + detectionAngle / 2) * Mathf.Deg2Rad), Mathf.Cos((LeftAngle + detectionAngle / 2) * Mathf.Deg2Rad)));
    }
#endif
}
