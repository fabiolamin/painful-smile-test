using System;
using UnityEngine;
using UnityEngine.UI;

namespace PirateGame.UI
{
    public class GameSessionTimeDisplay : MonoBehaviour
    {
        [SerializeField] private Text _timeDisplay;

        public void UpdateTimeDisplay(float currentTime)
        {
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            _timeDisplay.text = time.ToString(@"hh\:mm\:ss");
        }
    }
}

