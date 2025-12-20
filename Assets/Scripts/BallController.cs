using UnityEngine;
using Random = UnityEngine.Random;

namespace Breakout.Controllers
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private float speed = 2;
        [SerializeField] private GameManager gameManager;

        private Rigidbody2D _myRigidBody;
        private Vector2 _startingPosition;
        
        public Rigidbody2D RigidBody => _myRigidBody;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            AutoSetRigidBody();
            _startingPosition = transform.position;
            LaunchBall();
        }

        private void AutoSetRigidBody()
        {
            var rigidBoy = GetComponent<Rigidbody2D>();
            if (rigidBoy)
            {
                _myRigidBody = rigidBoy;
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

            _myRigidBody.linearVelocity = new Vector2(x, y) * speed;
        }

        private void FixedUpdate()
        {
            _myRigidBody.linearVelocity = _myRigidBody.linearVelocity.normalized * speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("PlayerLoseZone"))
            {
                return;
            }

            gameManager.PlayerDied();
        }
    }
}
