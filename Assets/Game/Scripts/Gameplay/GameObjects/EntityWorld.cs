using System.Collections.Generic;
using System.Linq;
using Game.Content.Enemies;
using Game.Core;
using R3;
using UnityEngine;
using Zenject;

namespace Game.GameObjects
{
    public class EntityWorld : IInitializable
    {
        private List<IEntity> _entities;

        private ReactiveProperty<int> _currentEnemiesCount;

        public ReadOnlyReactiveProperty<int> CurrentEnemiesCount => _currentEnemiesCount;

        public void Initialize()
        {
            _entities = new List<IEntity>(GameObject.FindObjectsOfType<Entity>());

            int enemiesCount = _entities.Count(entity => entity.TryGet(out Enemy enemy));
            _currentEnemiesCount = new ReactiveProperty<int>(enemiesCount);

            foreach (var entity in _entities)
                entity.OnDestroyed += OnEntityDestroyed;
        }

        private void OnEntityDestroyed(IEntity entity)
        {
            _entities.Remove(entity);

            if (entity.TryGet(out Enemy enemy))
                _currentEnemiesCount.Value--;

            entity.OnDestroyed -= OnEntityDestroyed;
        }
    }
}