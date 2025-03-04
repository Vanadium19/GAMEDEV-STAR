using System;

namespace Game.Modules.Entities
{
    public interface IEntity
    {
        public event Action<IEntity> OnDestroyed;

        public T Get<T>();
        public bool TryGet<T>(out T value) where T : class;
    }
}