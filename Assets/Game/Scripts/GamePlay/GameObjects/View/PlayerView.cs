using System;
using DG.Tweening;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private int _duration = 2;
        [SerializeField] private float _interval = 0.25f;

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _color;

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _jumpSound;
        [SerializeField] private AudioClip _deathSound;

        private Color _startColor;

        private void Awake()
        {
            _startColor = _spriteRenderer.color;
        }

        public void Die(Action callback)
        {
            _audioSource.PlayOneShot(_deathSound);
            _animator.SetTrigger(AnimatorParams.Die);
            _spriteRenderer.color = _startColor;

            _spriteRenderer.DOColor(_color, _interval)
                .SetLoops((int)(_duration / _interval), LoopType.Yoyo)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    callback?.Invoke();
                    _spriteRenderer.color = _startColor;
                });
        }

        public void SetMovingState(bool value)
        {
            _animator.SetBool(AnimatorParams.IsMoving, value);
        }

        public void SetFallingState(bool value)
        {
            _animator.SetBool(AnimatorParams.IsFalling, value);
        }

        public void Jump()
        {
            _audioSource.PlayOneShot(_jumpSound);
            _animator.SetTrigger(AnimatorParams.Jump);
        }
    }
}