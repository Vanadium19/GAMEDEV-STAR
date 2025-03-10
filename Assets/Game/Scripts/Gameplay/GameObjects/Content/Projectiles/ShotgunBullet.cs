using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Modules.Entities;
using UnityEngine;

namespace Game.Content.Projectiles
{
    public class ShotgunBullet : Bullet
    {
        private readonly IEntity _entity;
        private readonly float _delay;
        private readonly float _damageMultiplier;
        private readonly float _damageChangeDelay;

        private CancellationTokenSource _cancellationToken;

        public ShotgunBullet(IEntity entity, float damageMultiplier, float delay, Rigidbody rigidbody) : base(rigidbody)
        {
            _entity = entity;
            _delay = delay;
            _damageChangeDelay = delay / 2;
            _damageMultiplier = damageMultiplier;

            _cancellationToken = new CancellationTokenSource();
        }

        protected override void OnInitialize()
        {
            if (_cancellationToken.IsCancellationRequested)
                _cancellationToken = new CancellationTokenSource();

            _entity.OnDestroyed += OnEntityDestroyed;

            Destroy().Forget();
            ChangeDamage().Forget();
        }

        private async UniTaskVoid Destroy()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken: _cancellationToken.Token);

            _entity.OnDestroyed -= OnEntityDestroyed;
            _entity.Destroy();
        }

        private async UniTaskVoid ChangeDamage()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_damageChangeDelay), cancellationToken: _cancellationToken.Token);

            MultiplyDamage(_damageMultiplier);
        }

        private void OnEntityDestroyed(Entity entity)
        {
            _cancellationToken?.Cancel();

            _entity.OnDestroyed -= OnEntityDestroyed;
        }
    }
}