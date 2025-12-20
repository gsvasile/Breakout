using UnityEngine;
using Random = UnityEngine.Random;

namespace Breakout.Controllers
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private float speed = 2;
        [SerializeField] private GameManager gameManager;

        private Rigidbody2D _rigidbody;
        private Vector2 _startingPosition;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            AutoSetRigidBody();
            _startingPosition = transform.position;
            LaunchBall();
        }

        private void AutoSetRigidBody()
        {
            var rigidBody = GetComponent<Rigidbody2D>();
            if (rigidBody)
            {
                _rigidbody = rigidBody;
            }
        }

        public void LaunchBall()
        {
            transform.position = _startingPosition;

            float x = 0;
            float y = 1;

            var randomNumber = Random.Range(0, 2);

            switch (randomNumber)
            {
                case 0:
                {
                    x = 1;
                    break;
                }
                case 1:
                {
                    x = -1;
                    break;
                }
            }

            _rigidbody.linearVelocity = new Vector2(x, y) * speed;
        }

        private void FixedUpdate()
        {
            _rigidbody.linearVelocity = _rigidbody.linearVelocity.normalized * speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("PlayerLoseZone"))
            {
                return;
            }

            gameManager.PlayerDied();
        }

        public void Pause()
        {
            _rigidbody.linearVelocity = Vector2.zero;
        }
    }
}
