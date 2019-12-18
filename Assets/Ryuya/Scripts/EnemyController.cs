using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public ItemManeger.Types type
    {
        get; set;
    }

	[SerializeField] float maxSpeed = 5.0f;
	Rigidbody _rg;
	bool deathFlg = false;

    // Start is called before the first frame update
    void Start()
    {
		_rg = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
		_rg.velocity = -transform.forward * maxSpeed;
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
