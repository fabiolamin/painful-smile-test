using PirateGame.Data.Health;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace PirateGame.Health
{
    public class ShipHealth : MonoBehaviour
    {
        private GameObject _lastDamageSource = null;
        private float _currentHealth = 0f;
        private bool _isAlive = true;

        [SerializeField] private ShipHealthData _shipHealthData;
        [SerializeField] private SpriteRenderer _shipSpriteRenderer;
        [SerializeField] private UnityEvent _onDied;
        [SerializeField] private UnityEvent<float> _onHealthUpdated;
        [SerializeField] private UnityEvent<bool> _onCriticalState;
        [SerializeField] private UnityEvent _onDisabled;
        [SerializeField] private UnityEvent<GameObject> _onLastDamage;

        private void OnEnable()
        {
            _isAlive = true;
            _currentHealth = _shipHealthData.MaxHealth;
            UpdateHealth();
        }

        public void GetDamage(float damage, GameObject source)
        {
            if (_isAlive)
            {
                _lastDamageSource = source;
                _currentHealth = Mathf.Clamp(_currentHealth - damage, 0f, _shipHealthData.MaxHealth);
                UpdateHealth();
                CheckHealth();
            }
        }

        private void UpdateHealth()
        {
            _onHealthUpdated.Invoke(_currentHealth / _shipHealthData.MaxHealth);
            ShipState shipState = _shipHealthData.GetCurrentState(_currentHealth);
            _shipSpriteRenderer.sprite = shipState.State;
            _onCriticalState.Invoke(shipState.IsCriticalState);
        }

        private void CheckHealth()
        {
            if (_currentHealth <= 0f)
            {
                _isAlive = false;
                _onLastDamage.Invoke(_lastDamageSource);
                _onDied.Invoke();
                StartCoroutine(SetDeath());
            }
        }

        private IEnumerator SetDeath()
        {
            yield return new WaitForSeconds(_shipHealthData.DeathDelay);
            _onDisabled.Invoke();
            gameObject.SetActive(false);
        }

        public void TriggerOwnDeath()
        {
            GetDamage(_shipHealthData.MaxHealth, null);
        }
    }
}

