using Game.Core;
using Game.Core.Components;
using Game.Core.Inventories;

namespace Game.Content.Weapons
{
    public class WeaponCollector : ICollectable
    {
        private readonly IWeapon _weapon;

        protected WeaponCollector(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public void Collect(IEntity collector)
        {
            if (collector.TryGet(out IInventory inventory))
                inventory.AddWeapon(_weapon);
        }
    }
}