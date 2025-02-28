using System;
using System.Collections.Generic;
using Game.Core;
using Game.Core.Components;
using R3;
using UnityEngine;
using Zenject;

namespace Game.Content.Traps
{
    public class SlowZone : IInitializable, IDisposable
    {
        private readonly GameObject _gameObject;
        private readonly HealthComponent _health;
        private readonly float _multiplier;

        private readonly List<IMovable> _movables = new();

        private IDisposable _disposables;

        public SlowZone(GameObject gameObject, HealthComponent health, float multiplier)
        {
            _gameObject = gameObject;
            _health = health;
            _multiplier = multiplier;
        }

        public void Initialize()
        {
            var disposableBuilder = Disposable.CreateBuilder();

            _health.IsDead.Subscribe(OnDied).AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }

        public void Enter(IEntity entity)
        {
            if (!entity.TryGet(out IMovable movable))
                return;

            movable.ChangeSpeed(1 / _multiplier);
            _movables.Add(movable);
        }

        public void Exit(IEntity entity)
        {
            if (!entity.TryGet(out IMovable movable))
                return;

            if (_movables.Remove(movable))
                movable.ChangeSpeed(_multiplier);
        }

        private void OnDied(bool value)
        {
            if (!value)
                return;

            ClearMovables();
            GameObject.Destroy(_gameObject);
        }

        private void ClearMovables()
        {
            foreach (var movable in _movables)
                movable.ChangeSpeed(_multiplier);

            _movables.Clear();
        }
    }
}