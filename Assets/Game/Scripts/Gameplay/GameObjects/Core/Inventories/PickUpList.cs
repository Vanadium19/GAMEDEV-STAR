using System.Collections.Generic;
using Game.Modules.Entities;

namespace Game.Core.Components
{
    public class PickUpList : IPickUpList
    {
        private readonly IEntity _collector;

        private readonly List<ICollectable> _collectables = new();

        public PickUpList(IEntity collector)
        {
            _collector = collector;
        }

        public bool Add(ICollectable item)
        {
            if (_collectables.Contains(item))
                return false;

            _collectables.Add(item);
            return true;
        }

        public bool Remove(ICollectable item)
        {
            return _collectables.Remove(item);
        }

        public void Collect()
        {
            foreach (var collectable in _collectables)
                collectable.Collect(_collector);

            _collectables.Clear();
        }
    }
}