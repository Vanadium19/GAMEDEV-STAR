using System;
using Game.Core.Components;
using R3;
using UnityEngine;
using Zenject;

namespace Game.Content.Enemies
{
    public class Enemy : IInitializable, IDisposable
    {
        private readonly GameObject _gameObject;
        private readonly IDamagable _health;

        private IDisposable _disposables;

        public Enemy(GameObject gameObject, IDamagable health)
        {
            _gameObject = gameObject;
            _health = health;
        }

        public void Initialize()
        {
            var disposableBuilder = Disposable.CreateBuilder();

            _health.IsDead.Subscribe(OnDeathStatusChanged).AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        public void Dispose()
        {
            Debug.Log("Dead");

            _disposables.Dispose();
        }

        public void OnDeathStatusChanged(bool value)
        {
            if (value)
                GameObject.Destroy(_gameObject);
        }
    }
}