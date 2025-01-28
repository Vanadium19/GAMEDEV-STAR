using System;
using Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class Character : MonoBehaviour, IMovable, IDamagable, IJumper
    {
        private Transform _transform;

        private GroundChecker _groundChecker;
        private Rotater _rotater;
        private Mover _mover;
        private Jumper _jumper;
        private Health _health;

        private Transform _currentParent;
        private Vector3 _startPosition;

        public event Action<IDamagable> Died;
        
        public Vector2 Position => _transform.position;

        [Inject]
        public void Construct(GroundChecker groundChecker,
            Rotater rotater,
            Mover mover,
            Jumper jumper,
            Health health)
        {
            _groundChecker = groundChecker;
            _rotater = rotater;
            _mover = mover;
            _jumper = jumper;
            _health = health;
        }

        private void Awake()
        {
            _transform = transform;
            _startPosition = _transform.position;
        }

        private void OnEnable()
        {
            _health.Died += OnCharacterDied;
            _groundChecker.ParentChanged += SetParent;
        }

        private void OnDisable()
        {
            _health.Died -= OnCharacterDied;
            _groundChecker.ParentChanged -= SetParent;
        }

        public void Move(Vector2 direction)
        {
            _transform.SetParent(null);

            _mover.Move(direction);
            _rotater.Rotate(direction);

            _transform.SetParent(_currentParent);
        }

        public void Jump()
        {
            if (_groundChecker.IsGrounded)
                _jumper.Jump();
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        private void OnCharacterDied()
        {
            _transform.position = _startPosition;
            _health.ResetHealth();
            Died?.Invoke(this);
        }

        private void SetParent(Transform parent)
        {
            _transform.SetParent(parent);
            _currentParent = parent;
        }
    }
}