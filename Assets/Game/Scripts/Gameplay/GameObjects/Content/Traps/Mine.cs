using System;
using Game.Core.Components;
using Game.Modules.Entities;
using UnityEngine;
using Zenject;

namespace Game.Content.Traps
{
    public class Mine : IInitializable, IDisposable
    {
        private readonly IEntity _entity;
        private readonly IAttacker _attacker;

        public Mine(IAttacker attacker, IEntity entity)
        {
            _entity = entity;
            _attacker = attacker;
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
            _entity.Destroy();
        }
    }
}