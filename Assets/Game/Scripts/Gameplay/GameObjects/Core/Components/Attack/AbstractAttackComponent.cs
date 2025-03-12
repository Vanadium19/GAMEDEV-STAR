using Game.Modules.Entities;
using System;

namespace Game.Core.Components
{
    public abstract class AbstractAttackComponent : EntityComponent, IAttacker
    {
        public event Action Attacked;

        public abstract void Attack();

        protected void InvokeAttacked()
        {
            //destroy this pls!!!
            Attacked?.Invoke();
        }
    }
}
