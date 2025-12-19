using UnityEngine;

namespace Breakout
{
    public class Block : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                Destroy(gameObject);
            }
        }
    }
}
