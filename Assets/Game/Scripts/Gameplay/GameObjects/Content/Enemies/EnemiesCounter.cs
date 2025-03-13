using System;
using System.Linq;
using Game.Modules.Entities;
using R3;
using Zenject;

namespace Game.Content.Enemies
{
    public class EnemiesCounter : IInitializable, IDisposable
    {
        private readonly EntityWorld _entityWorld;

        private int _maxEnemiesCount;
        private ReactiveProperty<int> _currentEnemiesCount;

        public EnemiesCounter(EntityWorld entityWorld)
        {
            _entityWorld = entityWorld;
        }

        public int MaxEnemiesCount => _maxEnemiesCount;
        public ReadOnlyReactiveProperty<int> CurrentEnemiesCount => _currentEnemiesCount;

        public void Initialize()
        {
            _maxEnemiesCount = _entityWorld.Entities.Count(entity => entity.TryGet(out Enemy enemy));
            _currentEnemiesCount = new ReactiveProperty<int>(_maxEnemiesCount);

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