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

        private readonly Dictionary<string, Queue<Entity>> _pools = new();

        private List<Entity> _entities;

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
            _entities = new List<Entity>(GameObject.FindObjectsOfType<Entity>());

            foreach (var entity in _entities)
                entity.OnDestroyed += Despawn;
        }

        private void Despawn(Entity entity)
        {
            if (!_entities.Remove(entity))
                return;

            EntityRemoved?.Invoke(entity);

            if (!_pools.ContainsKey(entity.Id))
                _pools.Add(entity.Id, new Queue<Entity>());

            _pools[entity.Id].Enqueue(entity);

            entity.OnDestroyed -= Despawn;

            // foreach (var pool in _pools)
            //     Debug.Log($"Despawning entity {pool.Key} count {pool.Value.Count}");
        }

        public IEntity Spawn(string id, Vector3 position, Quaternion rotation)
        {
            if (!_entityCatalog.FindConfig(id, out EntityConfig config))
                throw new ArgumentException("Entity with id " + id + " does not exist");

            if (!_pools.ContainsKey(config.Name))
                _pools.Add(config.Name, new Queue<Entity>());

            Entity entity = _pools[id].Count > 0
                ? GetEntity(id, position, rotation)
                : Instantiate(position, rotation, config);

            entity.OnDestroyed += Despawn;

            _entities.Add(entity);
            EntityAdded?.Invoke(entity);
            return entity;
        }

        private Entity GetEntity(string id, Vector3 position, Quaternion rotation)
        {
            Entity entity = _pools[id].Dequeue();

            entity.gameObject.SetActive(true);
            entity.transform.SetPositionAndRotation(position, rotation);

            return entity;
        }

        private Entity Instantiate(Vector3 position, Quaternion rotation, EntityConfig config)
        {
            GameObject gameObject = _diContainer.InstantiatePrefab(config.Prefab, position, rotation, _container);
            gameObject.name = config.Name;

            return gameObject.GetComponent<Entity>();
        }
    }
}