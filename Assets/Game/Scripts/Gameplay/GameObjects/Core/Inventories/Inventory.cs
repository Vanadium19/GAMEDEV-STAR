using Game.Content.Weapons;
using Game.Core.Components;
using R3;
using UnityEngine;

namespace Game.Core.Inventories
{
    public class Inventory : IInventory
    {
        private const int DefaultWeaponIndex = 0;
        private const int ExtraWeaponIndex = 1;

        private readonly IWeapon[] _weapons = new IWeapon[2];
        private readonly Transform _handle;

        private readonly ReactiveProperty<IWeapon> _currentWeapon;

        private int _currentIndex = 0;

        public Inventory(Transform handle, IWeapon defaultWeapon)
        {
            _weapons[DefaultWeaponIndex] = defaultWeapon;
            _currentWeapon = new ReactiveProperty<IWeapon>(defaultWeapon);
            _handle = handle;
        }

        public ReadOnlyReactiveProperty<IWeapon> CurrentWeapon => _currentWeapon;

        public void AddWeapon(IWeapon weapon)
        {
            if (_weapons[ExtraWeaponIndex] != null)
                DropWeapon();

            weapon.Enable(false);
            weapon.PickUp(_handle);
            weapon.Emptied += DropWeapon;

            _weapons[ExtraWeaponIndex] = weapon;
            ChangeWeapon();
        }

        public void DropWeapon()
        {
            IWeapon weapon = _weapons[ExtraWeaponIndex];

            _currentWeapon.Value = _weapons[DefaultWeaponIndex];
            _currentWeapon.Value.Enable(true);

            _currentIndex = DefaultWeaponIndex;
            _weapons[ExtraWeaponIndex] = null;

            weapon.Emptied -= DropWeapon;
            weapon.Enable(true);
            weapon.Drop();
        }

        public void ChangeWeapon()
        {
            int index = (_currentIndex + 1) % _weapons.Length;

            if (_weapons[index] == null)
                return;

            for (int i = 0; i < _weapons.Length; i++)
                _weapons[i].Enable(i == index);

            _currentIndex = index;
            _currentWeapon.Value = _weapons[index];
        }
    }
}