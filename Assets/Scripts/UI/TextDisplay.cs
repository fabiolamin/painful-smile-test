using UnityEngine;
using UnityEngine.UI;

namespace PirateGame.UI
{
    public class TextDisplay : MonoBehaviour
    {
        [SerializeField] private Text _display;

        public void UpdateDisplay(float value)
        {
            _display.text = value.ToString();
        }
    }
}

