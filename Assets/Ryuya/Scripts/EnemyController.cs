using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public ItemManeger.Types type
    {
        get; set;
    }


	[SerializeField] float speed = 1.0f;
	[SerializeField] float maxSpeed = 6.0f;
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
		//if( _rg.velocity.magnitude < 6 )
		//{
		//	_rg.AddForce( transform.forward * speed );
		//}
		//else
		{
			_rg.velocity = transform.forward * maxSpeed;
		}
	}

	void OnTriggerStay( Collider other )
	{
		if( other.gameObject.tag == "Player" )
		{
			deathFlg = true;
			Debug.Log( deathFlg );
		}
	}
}
