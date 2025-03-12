using System;
using Game.Scripts.Common;
using R3;
using UnityEngine;

namespace Game.Content.Weapons
{
    public interface IWeapon
    {
        public event Action Emptied;

        public ReadOnlyReactiveProperty<int> AmmoCount { get; }

        public bool Shoot(TeamType team);
        public void PickUp(Transform parent);
        public void Drop();
        public void Enable(bool value);
    }
}