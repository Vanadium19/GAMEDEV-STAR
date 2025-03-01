using System;
using Game.Content.Weapons;
using UnityEngine;

namespace Game.Core.Components
{
    public class AttackComponent : EntityComponent, IAttacker
    {
        private readonly IWeapon _weapon;

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
    }
}