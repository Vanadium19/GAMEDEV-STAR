using Game.Core.Components;
using Game.Modules.Entities;
using UnityEngine;

namespace Game.Content.PickUp
{
    public class Medic : ICollectable
    {
        private readonly int _heal;

        public Medic(int heal)
        {
            _heal = heal;
        }

        public void Collect(IEntity collector)
        {
            if (collector.TryGet(out IHealable healable))
            {
                healable.TakeHeal(_heal);
                Debug.Log("Heal");
            }
        }
    }
}