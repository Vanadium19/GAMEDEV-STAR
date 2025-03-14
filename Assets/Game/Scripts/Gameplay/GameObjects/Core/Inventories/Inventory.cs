using Game.Content.Weapons;
using R3;
using UnityEngine;

namespace Game.Core.Inventories
{
    public class Inventory : IInventory
    {
        private const int DefaultWeaponIndex = 0;
        private const int ExtraWeaponIndex = 1;

        private readonly IWeapon[] _weapons = new IWeapon[2];
        private readonly WeaponCatalog _catalog;
        private readonly Transform _handle;

        private readonly ReactiveProperty<IWeapon> _currentWeapon;
        private readonly ReactiveProperty<Sprite> _weaponSprite;

        private int _currentIndex = 0;

        public Inventory(Transform handle, IWeapon defaultWeapon, WeaponCatalog catalog)
        {
            _weapons[DefaultWeaponIndex] = defaultWeapon;
            _currentWeapon = new ReactiveProperty<IWeapon>(defaultWeapon);
            _weaponSprite = new ReactiveProperty<Sprite>(catalog.GetWeaponImage(defaultWeapon));

            _handle = handle;
            _catalog = catalog;
        }

        public ReadOnlyReactiveProperty<IWeapon> CurrentWeapon => _currentWeapon;
        public ReadOnlyReactiveProperty<Sprite> WeaponSprite => _weaponSprite;

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
            SetWeapon(DefaultWeaponIndex);

            IWeapon weapon = _weapons[ExtraWeaponIndex];
            weapon.Emptied -= DropWeapon;
            weapon.Enable(true);
            weapon.Drop();

            _weapons[ExtraWeaponIndex] = null;
        }

        public void ChangeWeapon()
        {
            int index = (_currentIndex + 1) % _weapons.Length;

            if (_weapons[index] == null)
                return;

            SetWeapon(index);
        }

        private void SetWeapon(int index)
        {
            for (int i = 0; i < _weapons.Length; i++)
                _weapons[i].Enable(i == index);

            _currentIndex = index;
            _currentWeapon.Value = _weapons[index];
            _weaponSprite.Value = _catalog.GetWeaponImage(_weapons[index]);
        }
    }
}