using UnityEngine;

namespace PirateGame.Data.Movement
{
    [CreateAssetMenu(fileName = "Ship Movement Data", menuName = "Movement/new Ship Movement Data")]
    public class ShipMovementData : ScriptableObject
    {
        [SerializeField] private float _movementSpeed = 5f;
        [SerializeField] private float _rotationSpeed = 5f;

        public float MovementSpeed { get { return _movementSpeed; } }
        public float RotationSpeed { get { return _rotationSpeed; } }
    }
}

