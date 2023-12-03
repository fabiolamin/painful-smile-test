using UnityEngine;

namespace PirateGame.Combat
{
    [System.Serializable]
    public struct ShipComponent
    {
        public Transform Transform;
        public Vector2 Direction;
        public float Speed;
    }
}

