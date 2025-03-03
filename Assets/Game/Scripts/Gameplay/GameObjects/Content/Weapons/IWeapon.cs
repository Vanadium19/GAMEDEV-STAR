using System;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Content.Weapons
{
    public interface IWeapon
    {
        public event Action Emptied;
        
        public bool Shoot(TeamType team, out int shootedAmmoCount);
        public void PickUp(Transform parent);
        public void Drop();
        public void Enable(bool value);
    }
}