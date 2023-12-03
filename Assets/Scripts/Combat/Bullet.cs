using UnityEngine;
using PirateGame.Health;

namespace PirateGame.Combat
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        public float Damage { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag != gameObject.tag)
            {
                HitTarget(collision.gameObject);
                gameObject.SetActive(false);
            }
        }

        private void HitTarget(GameObject target)
        {
            ShipHealth shipHealth = target.GetComponent<ShipHealth>();

            if (shipHealth != null)
            {
                shipHealth.GetDamage(Damage, gameObject);
            }
        }

        public void MoveTowardsTo(Vector2 direction)
        {
            _rigidbody.AddForce(direction);
        }
    }
}

