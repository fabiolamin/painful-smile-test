using PirateGame.Data.Combat;
using PirateGame.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace PirateGame.Combat
{
    public class ShipShooting : MonoBehaviour
    {
        private bool _canShoot = true;

        [SerializeField] private ObjectPooling _objectPooling;
        [SerializeField] private Transform[] _bulletOrigins;
        [SerializeField] ShipCombatData _shipCombatData;
        [SerializeField] private UnityEvent _onShipShot;
        public void Shoot(Vector2 direction)
        {
            if (_canShoot)
            {
                _onShipShot.Invoke();

                foreach (Transform origin in _bulletOrigins)
                {
                    Bullet bullet = _objectPooling.GetObject().GetComponent<Bullet>();
                    SetUpBullet(origin, bullet);
                    bullet.MoveTowardsTo(direction * _shipCombatData.ShootingForce);
                }
            }
        }

        private void SetUpBullet(Transform origin, Bullet bullet)
        {
            bullet.transform.position = origin.position;
            bullet.gameObject.tag = gameObject.tag;
            bullet.Damage = _shipCombatData.Damage;
        }

        public void SetShootingModifier(float value)
        {
            _canShoot = value > 0f;
        }
    }
}

