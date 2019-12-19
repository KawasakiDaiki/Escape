using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public ItemManeger.Types type
    {
        get; set;
    }

	float maxSpeed = 8.0f;
	Rigidbody _rg;
	bool deathFlg = false;

    // Start is called before the first frame update
    void Start()
    {
		GetComponent<Rigidbody>().velocity = Vector3.back * maxSpeed;
	}

    // Update is called once per frame
    void Update()
    {
	}

	void OnTriggerEnter( Collider other )
	{
		if( other.gameObject.tag == "Player" )
		{
			Debug.Log( GameManager.Instance.State );
			GameManager.Instance.State = GameState.GameOver;
			Debug.Log( GameManager.Instance.State );
		}
	}
}
