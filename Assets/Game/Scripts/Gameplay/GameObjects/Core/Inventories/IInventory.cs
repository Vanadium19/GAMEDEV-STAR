using Game.Content.Weapons;
using R3;
using UnityEngine;

namespace Game.Core.Inventories
{
    public interface IInventory
    {
        public ReadOnlyReactiveProperty<IWeapon> CurrentWeapon { get; }
        public ReadOnlyReactiveProperty<Sprite> WeaponSprite { get; }

        void AddWeapon(IWeapon weapon);
        void ChangeWeapon();
    }
}