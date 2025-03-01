using Game.Content.Weapons;
using R3;

namespace Game.Core.Inventories
{
    public interface IInventory
    {
        public ReadOnlyReactiveProperty<IWeapon> CurrentWeapon { get; }

        void AddWeapon(IWeapon weapon);
        void ChangeWeapon();
    }
}