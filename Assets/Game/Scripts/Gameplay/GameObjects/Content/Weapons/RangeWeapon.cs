using System;
using UnityEngine;
using Game.Scripts.Common;

namespace Game.Content.Weapons
{
    public abstract class RangeWeapon : IWeapon
    {
        private readonly Transform _transform;

        public event Action Emptied;
        
        protected RangeWeapon(Transform transform)
        {
            _transform = transform;
        }

        public abstract bool Shoot(TeamType team, out int shootedAmmoCount);

        public void PickUp(Transform parent)
        {
            _transform.SetParent(parent);
            _transform.localPosition = Vector3.zero;
            _transform.localRotation = Quaternion.identity;
        }

        public void Drop()
        {
            _transform.SetParent(null);
        }

        public void Enable(bool value)
        {
            _transform.gameObject.SetActive(value);
        }

        protected void Destroy()
        {
            Emptied?.Invoke();
            
            GameObject.Destroy(_transform.gameObject);
        }
    }
}