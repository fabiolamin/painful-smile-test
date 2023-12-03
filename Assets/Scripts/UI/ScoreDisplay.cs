using PirateGame.Data.Score;
using UnityEngine;
using UnityEngine.UI;

namespace PirateGame.UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private ScoreData _scoreData;
        [SerializeField] private Text _scoreText;

        public void UpdateScoreDisplay()
        {
            _scoreText.text = _scoreData.Score.ToString();
        }
    }
}

