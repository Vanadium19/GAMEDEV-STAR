using System;
using Game.Core.Components;
using Game.Core.Inventories;
using R3;
using Zenject;

namespace Game.Content.Player
{
    public class Character : IInitializable, IDisposable
    {
        private readonly IInventory _inventory;
        private readonly AttackComponent _attackComponent;

        private IDisposable _disposables;

        public Character(AttackComponent attackComponent, IInventory inventory)
        {
            _attackComponent = attackComponent;
            _inventory = inventory;
        }

        public void Initialize()
        {
            var disposableBuilder = Disposable.CreateBuilder();

            _inventory.CurrentWeapon
                .Subscribe(weapon => _attackComponent.SetWeapon(weapon))
                .AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }
    }
}