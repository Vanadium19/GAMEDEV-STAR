using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private int _duration = 2;
        [SerializeField] private float _interval = 0.25f;

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _color;

        private Color _startColor;

        private void Awake()
        {
            _startColor = _spriteRenderer.color;
        }

        public void Die(Action callback)
        {
            _spriteRenderer.color = _startColor;

            _spriteRenderer.DOColor(_color, _interval)
                .SetLoops((int)(_duration / _interval), LoopType.Yoyo)
                .SetEase(Ease.Linear)
                .OnComplete(() => { callback?.Invoke(); _spriteRenderer.color = _startColor; });
        }
    }
}