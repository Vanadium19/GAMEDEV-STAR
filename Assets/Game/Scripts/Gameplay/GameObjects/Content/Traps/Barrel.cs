using System;
using Cysharp.Threading.Tasks;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Traps
{
    public class Barrel : IInitializable, IDisposable
    {
        private readonly IAttacker _attacker;
        private readonly float _delay;

        private readonly GameObject _gameObject;
        private readonly GameObject _barrel;
        private readonly GameObject _fire;

        private bool _isFired;

        public Barrel(IAttacker attacker,
            GameObject gameObject,
            GameObject barrel,
            GameObject fire,
            float delay)
        {
            _attacker = attacker;
            _gameObject = gameObject;
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

            GameObject.Destroy(_gameObject);
        }
    }
}