using System;
using Game.Content.Weapons;

namespace Game.Core.Components
{
    public class AttackComponent : EntityComponent, IAttacker
    {
        private IWeapon _weapon;

        public event Action Attacked;

        public AttackComponent(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public void Attack()
        {
            if (_weapon.Shoot())
                Attacked?.Invoke();
        }

        public void SetWeapon(IWeapon weapon)
        {
            _weapon = weapon;
        }
    }
}