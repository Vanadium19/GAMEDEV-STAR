using System;
using Cysharp.Threading.Tasks;
using Game.Core.Components;
using Game.Modules.Entities;
using R3;
using UnityEngine;
using Zenject;

namespace Game.Content.Traps
{
    public class Barrel : IInitializable, IDisposable
    {
        private readonly HealthComponent _health;
        private readonly IAttacker _attacker;
        private readonly IEntity _entity;
        private readonly float _delay;

        private readonly GameObject _barrel;
        private readonly GameObject _fire;

        private IDisposable _disposables;

        public Barrel(HealthComponent health,
            IAttacker attacker,
            IEntity entity,
            GameObject barrel,
            GameObject fire,
            float delay)
        {
            _attacker = attacker;
            _entity = entity;
            _barrel = barrel;
            _fire = fire;
            _delay = delay;
            _health = health;
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

        private void Explode()
        {
            _attacker.Attack();

            _barrel.SetActive(false);
            _fire.SetActive(true);

            Destroy().Forget();
        }

        private void OnDied(bool value)
        {
            if (value)
                Explode();
        }

        private async UniTaskVoid Destroy()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_delay));

            _barrel.SetActive(true);
            _fire.SetActive(false);
            _entity.Destroy();
        }
    }
}