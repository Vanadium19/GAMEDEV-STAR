using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Modules.Entities
{
    public class EntityWorld : IInitializable
    {
        private readonly EntityCatalog _entityCatalog;
        private readonly DiContainer _diContainer;
        private readonly Transform _container;

        private readonly Dictionary<string, Queue<IEntity>> _pools = new();

        private List<IEntity> _entities;

        public event Action<IEntity> EntityAdded;
        public event Action<IEntity> EntityRemoved;

        public EntityWorld(EntityCatalog entityCatalog, DiContainer diContainer, Transform container)
        {
            _entityCatalog = entityCatalog;
            _diContainer = diContainer;
            _container = container;
        }

        public IReadOnlyList<IEntity> Entities => _entities;

        public void Initialize()
        {
            _entities = new List<IEntity>(GameObject.FindObjectsOfType<Entity>());

            foreach (var entity in _entities)
                entity.OnDestroyed += Despawn;
        }

        private void Despawn(IEntity entity)
        {
            if (!_entities.Remove(entity))
                return;

            EntityRemoved?.Invoke(entity);

            if (!_pools.ContainsKey(entity.Id))
                _pools.Add(entity.Id, new Queue<IEntity>());

            _pools[entity.Id].Enqueue(entity);

            entity.OnDestroyed -= Despawn;

            // foreach (var pool in _pools)
            //     Debug.Log($"Despawning entity {pool.Key} count {pool.Value.Count}");
        }

        public void Spawn(string id, Vector3 position, Quaternion rotation)
        {
            if (!_entityCatalog.FindConfig(id, out EntityConfig config))
                return;

            if (!_pools.ContainsKey(config.Name))
                _pools.Add(config.Name, new Queue<IEntity>());

            IEntity entity = _pools[id].Count > 0
                ? _pools[id].Dequeue()
                : _diContainer.InstantiatePrefab(config.Prefab, position, rotation, _container).GetComponent<Entity>();

            entity.OnDestroyed += Despawn;

            _entities.Add(entity);
            EntityAdded?.Invoke(entity);
        }
    }
}