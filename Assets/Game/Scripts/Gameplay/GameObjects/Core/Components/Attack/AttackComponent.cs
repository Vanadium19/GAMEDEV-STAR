using System;
using Game.Content.Weapons;
using Game.Scripts.Common;

namespace Game.Core.Components
{
    public class AttackComponent : EntityComponent, IAttacker
    {
        private IWeapon _weapon;
        private TeamType _team;

        public event Action Attacked;

        public AttackComponent(IWeapon weapon, TeamType team)
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