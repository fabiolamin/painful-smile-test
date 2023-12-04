using UnityEngine;

namespace PirateGame.AI.Navigation
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private float _distance = 3f;

        public float Distance { get { return _distance; } }
    }
}

