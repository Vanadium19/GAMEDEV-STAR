using Game.Content.Weapons;
using Game.Scripts.Common;

namespace Game.Core.Components
{
    public class RangeAttackComponent : AbstractAttackComponent
    {
        private readonly TeamType _team;
        
        private IWeapon _weapon;

        public RangeAttackComponent(IWeapon weapon, TeamType team)
        {
            _weapon = weapon;
            _team = team;
        }

        public override void Attack()
        {
            if (!CheckConditions())
                return;

            if (_weapon.Shoot(_team))
                InvokeAttacked();
        }

        public void SetWeapon(IWeapon weapon)
        {
            _weapon = weapon;
        }
    }
}