using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

	[SerializeField]float speed = 1.0f;
	Rigidbody _rg;

    // Start is called before the first frame update
    void Start()
    {
		_rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		if( _rg.velocity.magnitude < 10 )
		{
			_rg.AddForce( transform.forward * speed );
		}
		else
		{
			_rg.velocity = transform.forward * 10;
		}
	}
}
