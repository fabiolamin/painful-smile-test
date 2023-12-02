using UnityEngine;

namespace PirateGame.Data.Health
{
    [System.Serializable]
    public struct ShipState
    {
        public float CurrentHealth;
        public Sprite State;
        public bool IsCriticalState;
    }
}