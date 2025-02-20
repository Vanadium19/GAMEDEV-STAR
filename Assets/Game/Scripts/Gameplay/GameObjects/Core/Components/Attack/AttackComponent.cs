using Game.Content.Weapons;
using UnityEngine;

namespace Game.Core.Components
{
    public class AttackComponent : EntityComponent, IAttacker
    {
        private readonly IWeapon _weapon;

        public AttackComponent(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public void Attack()
        {
            _weapon.Shoot();
        }
    }
}