using UnityEngine;

namespace PirateGame.Data.Combat
{
    [CreateAssetMenu(fileName = "Ship Combat Data", menuName = "Combat/ new Ship Combat Data")]
    public class ShipCombatData : ScriptableObject
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _shootingForce;
        [SerializeField] private float _reloadingTime;
        [SerializeField] private float _minShootingDistance;

        public float Damage { get { return _damage; } }
        public float ShootingForce { get { return _shootingForce; } }
        public float ReloadingTime { get { return _reloadingTime; } }
        public float MinShootingDistance { get { return _minShootingDistance; } }
    }
}

