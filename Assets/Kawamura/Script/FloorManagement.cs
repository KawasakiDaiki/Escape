using UnityEngine;
using UnityEngine.UI;

public class FloorManagement : MonoBehaviour
{
    public Text ScoreLabel;

    [SerializeField]
    private float _transformReset = -60;
    [SerializeField]
    private float _resetPosition = -240;
    [SerializeField]
    private float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.State == GameState.InGame)
        foreach (Transform item in transform)
        {
            item.localPosition += Vector3.forward * speed * Time.deltaTime;
            if (item.localPosition.z > 240)
            {
                item.localPosition += Vector3.forward * _resetPosition;
            }
        }
        GameManager.Instance.TotalDistance += speed * Time.deltaTime;
    }
}
