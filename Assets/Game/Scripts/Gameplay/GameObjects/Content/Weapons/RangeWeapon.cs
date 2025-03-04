using System;
using UnityEngine;
using Game.Scripts.Common;
using Zenject;

namespace Game.Content.Weapons
{
    public abstract class RangeWeapon : IWeapon, ITickable
    {
        private readonly Transform _transform;

        public event Action Emptied;

        private int _ammoCount;
        private float _delay;

        private float _currentTime;
        
        protected RangeWeapon(Transform transform, int ammoCount, float delay)
        {
            _transform = transform;
            _ammoCount = ammoCount;
            _delay = delay;
        }

        public void Tick()
        {
            _currentTime -= Time.deltaTime; 
        }

        public bool Shoot(TeamType team)
        {
            if(_currentTime > 0)
                return false;

            if (IsGunEmpty())
            {
                Destroy();
                return false;
            }


            SpawnBullet(team);
            _ammoCount = Mathf.Max(-1, _ammoCount - 1);
            _currentTime = _delay;
            return true;
        }
        
        protected abstract void SpawnBullet(TeamType team);

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

        protected bool IsGunEmpty() => _ammoCount <= 0 && _ammoCount != -1;

    }
}