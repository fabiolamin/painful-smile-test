using UnityEngine;
using System.Linq;
using System.Collections;

namespace PirateGame.Combat
{
    public class ShipCriticalStateAnimation : MonoBehaviour
    {
        private const string _criticalStateAnimationName = "Burning";
        private bool _haveComponentsLeft = false;

        [SerializeField] private Animator _animator;
        [SerializeField] private ShipComponent[] _shipComponents;
        [SerializeField] private float _componentsDuration = 3f;

        private void OnEnable()
        {
            _shipComponents.ToList().ForEach(c => c.Transform.gameObject.SetActive(false));
            _shipComponents.ToList().ForEach(c => c.Transform.position = transform.position);
            _shipComponents.ToList().ForEach(c => c.Transform.SetParent(transform));
            _haveComponentsLeft = false;
        }

        private void Update()
        {
            MovePirates();
        }

        private void MovePirates()
        {
            if (_haveComponentsLeft)
            {
                foreach (ShipComponent component in _shipComponents)
                {
                    component.Transform.SetParent(null);
                    component.Transform.Translate(component.Direction * component.Speed * Time.deltaTime);
                }
            }
        }

        public void SetCriticalState(bool isCriticalState)
        {
            _animator.SetBool(_criticalStateAnimationName, isCriticalState);
            CheckCrewEscaping(isCriticalState);
        }

        private void CheckCrewEscaping(bool isCriticalState)
        {
            if (isCriticalState && !_haveComponentsLeft)
            {
                _shipComponents.ToList().ForEach(p => p.Transform.gameObject.SetActive(true));
                _haveComponentsLeft = true;
                StartCoroutine(SetCrewEscapingDuration());
            }
        }

        private IEnumerator SetCrewEscapingDuration()
        {
            yield return new WaitForSeconds(_componentsDuration);
            _shipComponents.ToList().ForEach(p => p.Transform.gameObject.SetActive(false));
        }
    }
}

