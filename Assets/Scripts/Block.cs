using UnityEngine;

namespace Breakout
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private int health = 1;
        [SerializeField] private int points = 100; 

        private SpriteRenderer _spriteRenderer;
        private GameManager _gameManager;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            AutoSetSpriteRenderer();
            _gameManager = FindFirstObjectByType<GameManager>();
        }

        private void AutoSetSpriteRenderer()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Ball"))
            {
                return;
            }

            health--;
            _gameManager.AddScore(points);

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
