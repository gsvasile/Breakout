using UnityEngine;

namespace Breakout
{
    public class GameManager : MonoBehaviour
    {
        private int _score;

        public void AddScore(int points)
        {
            _score += points;
        }
    }
}
