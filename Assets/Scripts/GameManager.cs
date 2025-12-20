using Breakout.Controllers;
using TMPro;
using UnityEngine;

namespace Breakout
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private BallController ballController;
        [SerializeField] private TextMeshProUGUI scoreText;

        private int _score;
        private int _lives = 1;

        public void AddScore(int points)
        {
            _score += points;
            scoreText.text = _score.ToString();
        }

        public void PlayerDied()
        {
            _lives--;

            if (_lives <= 0)
            {
                // GAME OVER
                GameOver();
            }
            else
            {
                // Player still has more lives so reset player and ball
                ResetGame();
            }
        }

        private void GameOver()
        {
            ballController.RigidBody.linearVelocity = Vector2.zero;
        }

        private void ResetGame()
        {
            playerController.Reset();
            ballController.LaunchBall();
        }

        public void WinGame()
        {
        }
    }
}
