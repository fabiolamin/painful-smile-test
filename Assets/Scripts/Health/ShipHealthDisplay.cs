using UnityEngine;
using UnityEngine.UI;

namespace PirateGame.Health
{
    public class ShipHealthDisplay : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;

        public void UpdateHealthBar(float healthAmount)
        {
            _healthBar.fillAmount = healthAmount;
        }
    }
}

