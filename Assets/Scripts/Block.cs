using UnityEngine;

namespace Breakout
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private int health = 1;

        private SpriteRenderer _spriteRenderer;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            AutoSetSpriteRenderer();
        }

        private void AutoSetSpriteRenderer()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Ball"))
            {
                return;
            }

            health--;
            switch (health)
            {
                case <= 0:
                {
                    Destroy(gameObject);
                    break;
                }
                case 1:
                {
                    _spriteRenderer.color = Color.mediumSpringGreen;
                    break;
                }
                case 2:
                {
                    _spriteRenderer.color = Color.softYellow;
                    break;
                }
                case 3:
                {
                    _spriteRenderer.color = Color.red;
                    break;
                }
            }
        }
    }
}
