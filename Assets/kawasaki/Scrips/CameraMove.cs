using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField, Tooltip("追従するターゲット")]
    Transform Traget;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Traget.position, 0.5f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Traget.rotation, 0.3f);
    }
}
