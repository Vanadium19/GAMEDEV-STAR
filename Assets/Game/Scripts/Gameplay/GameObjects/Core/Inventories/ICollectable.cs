using Game.Modules.Entities;

namespace Game.Core.Components
{
    public interface ICollectable
    {
        public void Collect(IEntity collector);
    }
}