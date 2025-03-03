using System;
using Game.Content.Weapons;
using Game.Scripts.Common;

namespace Game.Core.Components
{
    public class RangeAttackComponent : EntityComponent, IAttacker
    {
        private readonly TeamType _team;
        
        private IWeapon _weapon;

        public event Action Attacked;

        public RangeAttackComponent(IWeapon weapon, TeamType team)
        {
            _weapon = weapon;
            _team = team;
        }

        public void Attack()
        {
            if (_weapon.Shoot(_team, out int shootedAmmo))
                Attacked?.Invoke();
        }

        public void SetWeapon(IWeapon weapon)
        {
            _weapon = weapon;
        }
    }
}