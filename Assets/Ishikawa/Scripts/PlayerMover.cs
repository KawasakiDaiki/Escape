using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMover : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        [SerializeField, Tooltip("最高速度")]
        private float maxSpeed;

        [SerializeField, Tooltip("加速度")]
        float acceleration;

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        // Update is called once per frame
        void Update()
        {
            PlayerTurn();
        }
        void FixedUpdate()
        {
            //maxSpeedまでは加速
            if (_rigidbody.velocity.magnitude < maxSpeed)
            {
                _rigidbody.AddForce(transform.forward * acceleration);
            }
            else//maxSpeed以上ならmaxSpeed固定
            {
                _rigidbody.velocity = transform.forward * maxSpeed;
            }
        }


        void PlayerTurn()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.RotateAround(transform.GetChild(0).transform.position, transform.up, -90);
                _rigidbody.velocity = transform.forward * _rigidbody.velocity.magnitude;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.RotateAround(transform.GetChild(0).transform.position, transform.up, 90);
                _rigidbody.velocity = transform.forward * _rigidbody.velocity.magnitude;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}
