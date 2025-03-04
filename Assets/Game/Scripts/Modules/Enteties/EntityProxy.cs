using System;
using UnityEngine;

namespace Game.Modules.Entities
{
    public class EntityProxy : MonoBehaviour, IEntity
    {
        [SerializeField] private Entity _entity;

        public event Action<Entity> OnDestroyed
        {
            add => _entity.OnDestroyed += value;
            remove => _entity.OnDestroyed -= value;
        }

        public string Id => _entity.Id;

        public T Get<T>() => _entity.Get<T>();

        public bool TryGet<T>(out T value) where T : class => _entity.TryGet(out value);

        public void Destroy() => _entity.Destroy();
    }
}