using Game.Core.Components;
using Game.Modules.Entities;
using UnityEngine;

namespace Game.Content.PickUp
{
    public class Medic : ICollectable
    {
        private readonly int _heal;
        private readonly IEntity _entity;

        public Medic(int heal, IEntity entity)
        {
            _heal = heal;
            _entity = entity;
        }

        public void Collect(IEntity collector)
        {
            if (collector.TryGet(out IHealable healable))
            {
                healable.TakeHeal(_heal);
                _entity.Destroy();
            }
        }
    }
}