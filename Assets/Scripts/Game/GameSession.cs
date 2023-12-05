using PirateGame.Data.Game;
using PirateGame.Data.Score;
using UnityEngine;
using UnityEngine.Events;

namespace PirateGame.Game
{
    public class GameSession : MonoBehaviour
    {
        private float _currentSessionTime = 0f;
        private bool _isSessionFinished = false;

        [SerializeField] private GameSessionData _gameSessionData;
        [SerializeField] private ScoreData _playerScoreData; 
        [SerializeField] private UnityEvent<float> _onSessionTimeUpdated;
        [SerializeField] private UnityEvent _onSessionFinished;

        private void Awake()
        {
            _playerScoreData.ResetScore();
            _currentSessionTime = PlayerPrefs.GetFloat(_gameSessionData.SessionTimeID);
        }

        private void Update()
        {
            CheckSession();
        }

        private void CheckSession()
        {
            if (!_isSessionFinished)
            {
                _currentSessionTime -= Time.deltaTime;
                _onSessionTimeUpdated.Invoke(_currentSessionTime);

                if (_currentSessionTime <= 0f)
                {
                    _isSessionFinished = true;
                    _onSessionFinished.Invoke();
                    PauseSession(true);
                }
            }
        }

        public void PauseSession(bool isPaused)
        {
            Time.timeScale = isPaused ? 0f : 1f;
        }
    }
}

