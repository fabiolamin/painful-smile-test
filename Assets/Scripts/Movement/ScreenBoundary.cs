using UnityEngine;

namespace PirateGame.Movement
{
    public class ScreenBoundary : MonoBehaviour
    {
        private float _xMin, _xMax;
        private float _yMin, _yMax;
        private Vector3 _size;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            SetParameters();
        }

        private void LateUpdate()
        {
            float x = Mathf.Clamp(transform.position.x, _xMin + _size.x, _xMax - _size.x);
            float y = Mathf.Clamp(transform.position.y, _yMin + _size.y, _yMax - _size.y);

            transform.position = new Vector2(x, y);
        }

        private void SetParameters()
        {
            _size = _spriteRenderer.sprite.bounds.extents;

            _xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
            _xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

            _yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
            _yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        }
    }
}

