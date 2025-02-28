using System;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Traps
{
    public class Mine : IInitializable, IDisposable
    {
        private readonly IAttacker _attacker;
        private readonly GameObject _gameObject;

        public Mine(IAttacker attacker, GameObject gameObject)
        {
            _attacker = attacker;
            _gameObject = gameObject;
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
            GameObject.Destroy(_gameObject);
        }
    }
}