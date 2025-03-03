using System;
using UnityEngine;
using Game.Scripts.Common;

namespace Game.Content.Weapons
{
    public abstract class RangeWeapon : IWeapon
    {
        private readonly Transform _transform;

        public event Action Emptied;

        private int _ammoCount;
        
        protected RangeWeapon(Transform transform, int ammoCount)
        {
            _transform = transform;
            _ammoCount = ammoCount;
        }

        public bool Shoot(TeamType team)
        {
            if(SpawnBullet(team) == 0)
                return false;

            _ammoCount -= SpawnBullet(team);

            if(IsGunEmpty())
                Destroy();
            
            return true;
        }
        protected bool IsGunEmpty() => Mathf.Max(_ammoCount, 0) == 0;
        protected abstract int SpawnBullet(TeamType team);

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

        private void Destroy()
        {
            Emptied?.Invoke();
            
            GameObject.Destroy(_transform.gameObject);
        }
    }
}