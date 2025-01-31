using System;
using Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class Character : MonoBehaviour, IMovable, IDamagable, IJumper
    {
        private Transform _transform;
        private ILevelRestarter _levelRestarter;

        private GroundChecker _groundChecker;
        private Rotater _rotater;
        private Mover _mover;
        private Jumper _jumper;
        private Health _health;

        private Transform _currentParent;
        private Vector3 _startPosition;
        private bool _isDead;
        
        public event Action<Action> Died;

        public Vector2 Position => _transform.position;

        [Inject]
        public void Construct(ILevelRestarter levelRestarter,
            GroundChecker groundChecker,
            Rotater rotater,
            Mover mover,
            Jumper jumper,
            Health health)
        {
            _levelRestarter = levelRestarter;
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
            if (_isDead)
                return;
            
            _transform.SetParent(null);

            _mover.Move(direction);
            _rotater.Rotate(direction);

            _transform.SetParent(_currentParent);
        }

        public void Jump()
        {
            if (_isDead)
                return;
            
            if (_groundChecker.IsGrounded)
                _jumper.Jump();
        }

        public void TakeDamage(int damage)
        {
            if (_isDead)
                return;
            
            _health.TakeDamage(damage);
        }

        private void Die()
        {
            _transform.position = _startPosition;

            _health.ResetHealth();
            _levelRestarter.RestartLevel();
            _isDead = false;
        }

        private void OnCharacterDied()
        {
            _isDead = true;
            _mover.Move(Vector2.zero);
            
            Died?.Invoke(Die);
        }

        private void SetParent(Transform parent)
        {
            _transform.SetParent(parent);
            _currentParent = parent;
        }
    }
}