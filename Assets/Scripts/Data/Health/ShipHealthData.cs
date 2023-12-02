using UnityEngine;
using System.Linq;

namespace PirateGame.Data.Health
{
    [CreateAssetMenu(fileName = "Ship Health Data", menuName = "Health/new Ship Health Data")]
    public class ShipHealthData : ScriptableObject
    {
        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private ShipState[] _shipStates;
        [SerializeField] private float _deathDelay = 3f;

        public float MaxHealth { get { return _maxHealth; } }

        public IOrderedEnumerable<ShipState> States => _shipStates.OrderBy(s => s.CurrentHealth);

        public float DeathDelay { get { return _deathDelay; } }

        public ShipState GetCurrentState(float currentHealth)
        {
            return States.FirstOrDefault(s => s.CurrentHealth >= currentHealth);
        }
    }
}

