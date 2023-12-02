using PirateGame.Data.Movement;
using UnityEngine;

namespace PirateGame.Movement
{
    public class ShipMovement : MonoBehaviour
    {
        private int _movementModifier = 1;

        [SerializeField] private ShipMovementData _movementData;

        public void Move(Vector2 newPosition)
        {
            float speed = _movementData.MovementSpeed * Time.deltaTime * _movementModifier;
            transform.position += new Vector3(newPosition.x * speed, newPosition.y * speed, transform.position.z);

            Rotate(newPosition);
        }

        private void Rotate(Vector2 newPosition)
        {
            if (newPosition.magnitude != 0f)
            {
                float zDegree = Mathf.Atan2(newPosition.y, newPosition.x) * Mathf.Rad2Deg;
                Quaternion newRotation = Quaternion.Euler(0f, 0f, zDegree);
                float speed = _movementData.RotationSpeed * Time.deltaTime * _movementModifier;
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speed);
            }
        }

        public void SetMovementModifier(float value)
        {
            _movementModifier = value > 0 ? 1 : 0;
        }
    }
}

