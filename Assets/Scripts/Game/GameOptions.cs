using PirateGame.Data.Game;
using UnityEngine;
using UnityEngine.UI;

namespace PirateGame.Game
{
    public class GameOptions : MonoBehaviour
    {
        [SerializeField] private GameSessionData _gameSessionData;

        [SerializeField] private Slider _sessionTimeSlider;
        [SerializeField] private Slider _respawnTimeSlider;

        private void Awake()
        {
            CheckOptions();
        }

        private void CheckOptions()
        {
            if (!HasAlreadyBeenSaved())
            {
                UpdateSliders(_gameSessionData.SessionTime, _gameSessionData.EnemySpawnTime);
                SaveOptions();
            }
            else
            {
                UpdateSliders(PlayerPrefs.GetFloat(_gameSessionData.SessionTimeID) / 60f,
                PlayerPrefs.GetFloat(_gameSessionData.EnemySpawnTimeID));
            }
        }

        private bool HasAlreadyBeenSaved()
        {
            return PlayerPrefs.GetFloat(_gameSessionData.SessionTimeID) != 0 &&
            PlayerPrefs.GetFloat(_gameSessionData.EnemySpawnTimeID) != 0;
        }

        private void UpdateSliders(float sessionTime, float respawnTime)
        {
            _sessionTimeSlider.value = sessionTime;
            _respawnTimeSlider.value = respawnTime;
        }

        public void SaveOptions()
        {
            PlayerPrefs.SetFloat(_gameSessionData.SessionTimeID, _sessionTimeSlider.value * 60f);
            PlayerPrefs.SetFloat(_gameSessionData.EnemySpawnTimeID, _respawnTimeSlider.value);
        }
    }
}

