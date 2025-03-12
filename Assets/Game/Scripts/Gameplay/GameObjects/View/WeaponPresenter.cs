using Game.Core.Components;
using Game.View;
using System;
using Zenject;

namespace Game.View
{
    public class WeaponPresenter : IInitializable, IDisposable
    {
        private readonly IAttacker _attacker;
        private readonly WeaponView _weaponView;
        
        public WeaponPresenter(IAttacker attacker, WeaponView weaponView)
        {
            _attacker = attacker;
            _weaponView = weaponView;
        }

        public void Initialize()
        {
            _attacker.Attacked += OnAttacked;
        }
        
        public void Dispose()
        {
            _attacker.Attacked -= OnAttacked;
        }

        private void OnAttacked()
        {
            _weaponView.OnWeaponShoot();
        }
    }
}
