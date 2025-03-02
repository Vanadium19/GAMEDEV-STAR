using System;
using UnityEngine;

namespace Game.Content.Weapons
{
    public abstract class RangeWeapon : IWeapon
    {
        private readonly Transform _transform;

        protected RangeWeapon(Transform transform)
        {
            _transform = transform;
        }

        public event Action Emptied;
        
        public abstract bool Shoot();

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