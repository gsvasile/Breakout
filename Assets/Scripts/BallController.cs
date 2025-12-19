using UnityEngine;
using Random = UnityEngine.Random;

namespace Breakout.Controllers
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D myRigidBody;
        [SerializeField] private float speed = 2;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            AutoSetRigidBody();
            LaunchBall();
        }

        private void AutoSetRigidBody()
        {
            if (myRigidBody != null)
            {
                return;
            }

            var rigidBoy = GetComponent<Rigidbody2D>();
            if (rigidBoy != null)
            {
                myRigidBody = rigidBoy;
            }
        }

        private void FixedUpdate()
        {
            myRigidBody.linearVelocity = myRigidBody.linearVelocity.normalized * speed;
        }

        public void LaunchBall()
        {
            transform.position = Vector2.zero;

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

            myRigidBody.linearVelocity = new Vector2(x, y) * speed;
        }
    }
}
