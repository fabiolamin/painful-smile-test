using PirateGame.Data.Combat;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace PirateGame.Inputs
{
    public class PlayerInputController : MonoBehaviour
    {
        private Vector2 _movementInput;

        private float _timeSinceLastShootingInput = 0f;
        private bool _canShootingInputBeTriggered = true;

        [SerializeField] private UnityEvent<Vector2> _onPlayerMoved;
        [SerializeField] private UnityEvent<Vector2> _onFire1ButtonTriggered;
        [SerializeField] private UnityEvent<Vector2> _onFire2ButtonTriggered;
        [SerializeField] private ShipCombatData _shipCombatData;

        private void Update()
        {
            CheckAttackInput();

            _onPlayerMoved.Invoke(_movementInput);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _movementInput = context.ReadValue<Vector2>();
        }

        public void OnAttack1(InputAction.CallbackContext context)
        {
            if (context.performed && _canShootingInputBeTriggered)
            {
                _onFire1ButtonTriggered.Invoke(transform.right);
                _canShootingInputBeTriggered = false;
            }
        }

        public void OnAttack2(InputAction.CallbackContext context)
        {
            if (context.performed && _canShootingInputBeTriggered)
            {
                _onFire2ButtonTriggered.Invoke(transform.up);
                _onFire2ButtonTriggered.Invoke(-transform.up);
                _canShootingInputBeTriggered = false;
            }
        }

        private void CheckAttackInput()
        {
            if (!_canShootingInputBeTriggered)
            {
                _timeSinceLastShootingInput += Time.deltaTime;

                if (_timeSinceLastShootingInput >= _shipCombatData.ReloadingTime)
                {
                    _canShootingInputBeTriggered = true;
                    _timeSinceLastShootingInput = 0f;
                }
            }
        }
    }
}

