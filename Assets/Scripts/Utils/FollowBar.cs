using UnityEngine;

namespace PirateGame.Utils
{
    public class FollowBar : MonoBehaviour
    {
        private Transform _target;
        private Vector3 _offset;

        private void Awake()
        {
            _target = transform.parent;
            _offset = transform.position - _target.position;
        }

        private void LateUpdate()
        {
            transform.position = _target.position + _offset;
            transform.LookAt(Camera.main.transform.position);
        }
    }
}

