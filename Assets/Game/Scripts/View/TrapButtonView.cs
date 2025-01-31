using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.View
{
    public class TrapButtonView : MonoBehaviour
    {
        [SerializeField] private float _duration = 0.2f;

        private Transform _transform;
        private float _bottomPosition;
        private bool _isActivated;

        private void Awake()
        {
            _transform = transform;
            _bottomPosition = _transform.position.y - _transform.lossyScale.y;
        }

        private void OnTriggerEnter2D(Collider2D target)
        {
            if (_isActivated)
                return;

            _isActivated = true;

            _transform.DOMoveY(_bottomPosition, _duration)
                .SetEase(Ease.Linear)
                .SetLoops(2, LoopType.Yoyo)
                .OnComplete(() => _isActivated = false);
        }
    }
}