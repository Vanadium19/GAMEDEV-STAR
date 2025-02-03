using System;
using Game.Core.Components;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Content.Player
{
    public class Character : IInitializable, ITickable, IDisposable, IMovable, IDamagable, IJumper
    {
        private readonly Health _health;
        private readonly Transform _transform;
        private readonly ILevelRestarter _levelRestarter;
        
        private readonly Mover _mover;
        private readonly Jumper _jumper;
        private readonly Rotater _rotater;
        private readonly Vector3 _startPosition;
        private readonly GroundChecker _groundChecker;

        private readonly ReactiveProperty<bool> _isMoving = new();
        private readonly ReactiveProperty<bool> _isFalling = new();
        private readonly ReactiveCommand<Action> _died = new();
        private readonly ReactiveCommand _jumped = new();

        private Transform _currentParent;
        private bool _isDead;
        
        public Character(ILevelRestarter levelRestarter,
            GroundChecker groundChecker,
            Transform transform,
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

            _transform = transform;
            _startPosition = _transform.position;
        }

        public Vector2 Position => _transform.position;
        public IReadOnlyReactiveProperty<bool> IsMoving => _isMoving;
        public IReadOnlyReactiveProperty<bool> IsFalling => _isFalling;
        public IObservable<Action> Died => _died; 
        public IObservable<Unit> Jumped => _jumped; 

        public void Initialize()
        {
            _health.Died += OnCharacterDied;
        }

        public void Tick()
        {
            var velocity = _mover.Velocity;
            
            _isMoving.Value = !Mathf.Approximately(0, velocity.x);
            _isFalling.Value = velocity.y < 0;
        }

        public void Dispose()
        {
            _health.Died -= OnCharacterDied;
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
            {
                if (_jumper.Jump())
                    _jumped.Execute();
            }
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
            _mover.FreezePosition(false);
            _isDead = false;
        }

        private void OnCharacterDied()
        {
            _isDead = true;
            _mover.FreezePosition(true);

            _died?.Execute(Die);
        }
    }
}