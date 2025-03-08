using System;
using Game.Core.Components;
using Game.Modules.Entities;
using R3;
using UnityEngine;
using Zenject;

namespace Game.Content.Enemies
{
    public class Enemy : IInitializable, IDisposable
    {
        private readonly IEntity _entity;
        private readonly IHealth _health;

        private IDisposable _disposables;

        public Enemy(IEntity entity, IHealth health)
        {
            _entity = entity;
            _health = health;
        }

        public void Initialize()
        {
            var disposableBuilder = Disposable.CreateBuilder();

            _health.IsDead.Where(value => value)
                .Subscribe(OnDeathStatusChanged)
                .AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        private void OnDeathStatusChanged(bool value)
        {
            _entity.Destroy();

            Debug.Log("Враг умер!");
        }
    }
}