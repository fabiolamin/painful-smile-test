using PirateGame.Data.Score;
using UnityEngine;

namespace PirateGame.Score
{
    public class Scorer : MonoBehaviour
    {
        [SerializeField] private ScoreData _scoreData;
        [SerializeField] private int _points = 1;

        public void AddPoints(GameObject scorer)
        {
            if(scorer != null)
            {
                _scoreData.AddPoints(_points);
            }
        }
    }
}

