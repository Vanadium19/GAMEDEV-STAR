using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Modules.Entities
{
    public class EntityWorld : IInitializable
    {
        private List<IEntity> _entities;

        // public event Action<Entity> EntityAdded;
        public event Action<IEntity> EntityRemoved;

        public IReadOnlyList<IEntity> Entities => _entities;

        public void Initialize()
        {
            _entities = new List<IEntity>(GameObject.FindObjectsOfType<Entity>());

            foreach (var entity in _entities)
                entity.OnDestroyed += OnEntityDestroyed;
        }

        private void OnEntityDestroyed(IEntity entity)
        {
            if (_entities.Remove(entity))
                EntityRemoved?.Invoke(entity);

            entity.OnDestroyed -= OnEntityDestroyed;
        }
    }
}