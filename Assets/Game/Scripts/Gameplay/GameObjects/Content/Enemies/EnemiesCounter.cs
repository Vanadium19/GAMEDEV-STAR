using System;
using System.Linq;
using Game.Modules.Entities;
using log4net.Util;
using R3;
using UnityEngine;
using Zenject;
using Transform = UnityEngine.Transform;

namespace Game.Content.Enemies
{
    public class EnemiesCounter : IInitializable, IDisposable
    {
        private readonly EntityWorld _entityWorld;
        private ReactiveProperty<int> _currentEnemiesCount;

        public ReadOnlyReactiveProperty<int> CurrentEnemiesCount => _currentEnemiesCount;

        public EnemiesCounter(EntityWorld entityWorld)
        {
            _entityWorld = entityWorld;
        }

        public void Initialize()
        {
            int enemiesCount = _entityWorld.Entities.Count(entity => entity.TryGet(out Enemy enemy));
            _currentEnemiesCount = new ReactiveProperty<int>(enemiesCount);

            _entityWorld.EntityRemoved += OnEntityRemoved;
        }

        public void Dispose()
        {
            _entityWorld.EntityRemoved -= OnEntityRemoved;
        }

        private void OnEntityRemoved(IEntity entity)
        {
            if (entity.TryGet(out Enemy enemy))
                _currentEnemiesCount.Value--;
        }
    }
}