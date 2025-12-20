using UnityEngine;
using UnityEngine.InputSystem;

namespace Breakout.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float speed = 2f;

        [Header("Player Input")]
        [SerializeField] private Key rightKey = Key.D;
        [SerializeField] private Key leftKey = Key.A;

        private Rigidbody2D _myRigidBody;
        // Stores direction that the player will move
        private float _direction;
        private Vector2 _startingPosition;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            AutoSetRigidBody();
            _startingPosition = transform.position;
        }

        private void AutoSetRigidBody()
        {
            var rigidBody = GetComponent<Rigidbody2D>();
            if (rigidBody)
            {
                _myRigidBody = rigidBody;
            }
        }

        // Update is called once per frame
        private void Update()
        {
            PlayerInput();
        }

        private void FixedUpdate()
        {
            _myRigidBody.linearVelocity = new Vector2(_direction, 0) * speed;
        }

        private void PlayerInput()
        {
            var kb = Keyboard.current;
            if (kb == null)
            {
                return;
            }

            if ((rightKey != Key.None && kb[rightKey].IsPressed()) ||
                kb.rightArrowKey.IsPressed())
            {
                _direction = 1f;
            }
            else if ((leftKey != Key.None && kb[leftKey].IsPressed()) ||
                     kb.leftArrowKey.IsPressed())
            {
                _direction = -1f;
            }
            else
            {
                _direction = 0f;
            }
        }

        public void Reset()
        {
            transform.position = _startingPosition;
        }
    }
}
