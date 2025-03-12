using System;
using Game.Content.Player;
using Game.Content.Weapons;
using Game.Core.Inventories;
using R3;
using Zenject;

namespace Game.UI
{
    public class InventoryPresenter : IInitializable, IDisposable
    {
        private readonly CharacterProvider _player;
        private readonly InventoryView _view;

        private IInventory _inventory;
        private IDisposable _disposables;
        private IDisposable _ammoDisposable;

        public InventoryPresenter(CharacterProvider player, InventoryView view)
        {
            _view = view;
            _player = player;
        }

        public void Initialize()
        {
            _inventory = _player.Get<IInventory>();

            var builder = Disposable.CreateBuilder();

            _inventory.WeaponSprite
                .Subscribe(sprite => _view.ChangeWeapon(sprite))
                .AddTo(ref builder);

            _inventory.CurrentWeapon
                .Subscribe(OnWeaponChanged)
                .AddTo(ref builder);

            _disposables = builder.Build();
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }

        private void OnWeaponChanged(IWeapon weapon)
        {
            _ammoDisposable?.Dispose();

            _view.EnableAmmoPanel(weapon.AmmoCount.CurrentValue != RangeWeapon.InfiniteAmmo);

            _ammoDisposable = weapon.AmmoCount.Subscribe(OnAmmoChanged);
        }

        private void OnAmmoChanged(int ammo)
        {
            _view.SetAmmoCount(ammo.ToString());
        }
    }
}