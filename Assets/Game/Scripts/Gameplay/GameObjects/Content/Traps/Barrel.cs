using System;
using Cysharp.Threading.Tasks;
using Game.Core.Components;
using Game.Modules.Entities;
using UnityEngine;
using Zenject;

namespace Game.Content.Traps
{
    public class Barrel : IInitializable, IDisposable
    {
        private readonly IAttacker _attacker;
        private readonly IEntity _entity;
        private readonly float _delay;

        private readonly GameObject _barrel;
        private readonly GameObject _fire;

        private bool _isFired;

        public Barrel(IAttacker attacker,
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
        }

        public void Initialize()
        {
            _attacker.Attacked += OnAttacked;
        }

        public void Dispose()
        {
            _attacker.Attacked -= OnAttacked;
        }

        private void OnAttacked()
        {
            if (_isFired)
                return;

            _barrel.SetActive(false);
            _fire.SetActive(true);
            Destroy().Forget();
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