using Breakout.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Breakout
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private BallController ballController;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;

        private int _score;
        private int _lives = 1;
        private readonly string _startingSceneName = "Breakout";

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
            PauseGame();
            losePanel.SetActive(true);
        }

        private void PauseGame()
        {
            playerController.Pause();
            ballController.Pause();
        }

        private void ResetGame()
        {
            winPanel.SetActive(false);
            losePanel.SetActive(false);
            playerController.Reset();
            ballController.LaunchBall();
        }

        public void WinGame()
        {
            PauseGame();
            winPanel.SetActive(true);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(_startingSceneName);
        }
    }
}
