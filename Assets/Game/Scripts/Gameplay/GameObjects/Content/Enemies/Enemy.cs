using System;
using Cysharp.Threading.Tasks;
using Game.Core.Components;
using Game.Modules.Entities;
using R3;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Content.Enemies
{
    public class Enemy : IInitializable, IDisposable
    {
        private const float _destroyDelay = 1.0f;
        
        private readonly IEntity _entity;
        private readonly IHealth _health;

        private readonly MoveComponent _moveComponent;
        private readonly AbstractAttackComponent _attackComponent;
        private readonly RotationComponent _rotationComponent;

        private IDisposable _disposables;

        public Enemy(IEntity entity,
            IHealth health,
            MoveComponent moveComponent,
            AbstractAttackComponent attackComponent,
            RotationComponent rotationComponent)
        {
            _entity = entity;
            _health = health;
            _moveComponent = moveComponent;
            _attackComponent = attackComponent;
            _rotationComponent = rotationComponent;
        }

        public void Initialize()
        {
            _moveComponent.AddCondition(() => !_health.IsDead.CurrentValue);
            _attackComponent.AddCondition(() => !_health.IsDead.CurrentValue);
            _rotationComponent.AddCondition(() => !_health.IsDead.CurrentValue);
            
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
            DestroyEntityAsync().Forget();
            Debug.Log("Враг умер!");
        }

        private async UniTaskVoid DestroyEntityAsync()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_destroyDelay));
            
            _entity.Destroy();
        }
    }
}