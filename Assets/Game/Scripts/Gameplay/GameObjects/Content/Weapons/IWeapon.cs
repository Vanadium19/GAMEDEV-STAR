using UnityEngine;

namespace Game.Content.Weapons
{
    public interface IWeapon
    {
        public bool Shoot();
        public void PickUp(Transform parent);
        public void Drop();
        public void Enable(bool value);
    }
}