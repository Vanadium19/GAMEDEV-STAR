using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.View
{
    public class CameraTracker : MonoBehaviour
    {
        [SerializeField] private float _minX, _maxX;
        [SerializeField] private float _minY, _maxY;
        [SerializeField] private Vector3 _offset;

        [SerializeField] private Transform _target;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void LateUpdate()
        {
            var position = _target.position + _offset;

            position.x = Mathf.Clamp(position.x, _minX, _maxX);
            position.y = Mathf.Clamp(position.y, _minY, _maxY);

            _transform.position = position;
        }
    }
}