using System;
using Game.Modules.Entities;
using UnityEngine;
using Game.Scripts.Common;
using Zenject;

namespace Game.Content.Weapons
{
    public abstract class RangeWeapon : IWeapon, ITickable
    {
        private const int InfiniteAmmo = -1;

        private readonly IEntity _entity;
        private readonly Transform _transform;
        private readonly float _delay;

        private int _ammoCount;
        private float _currentTime;

        public event Action Emptied;

        protected RangeWeapon(IEntity entity, Transform transform, int ammoCount, float delay)
        {
            _entity = entity;
            _transform = transform;
            _ammoCount = ammoCount;
            _delay = delay;
        }

        private bool IsGunEmpty => _ammoCount == 0;

        public void Tick()
        {
            if (_currentTime > 0)
                _currentTime -= Time.deltaTime;
        }

        public bool Shoot(TeamType team)
        {
            if (_currentTime > 0)
                return false;

            if (IsGunEmpty)
                return false;

            SpawnBullet(team);
            SubtractAmmo();

            _currentTime = _delay;
            return true;
        }

        public void PickUp(Transform parent)
        {
            _transform.SetParent(parent);
            _transform.localPosition = Vector3.zero;
            _transform.localRotation = Quaternion.identity;
        }

        public void Enable(bool value)
        {
            _transform.gameObject.SetActive(value);
        }

        public void Drop()
        {
            _transform.SetParent(null);
        }

        protected abstract void SpawnBullet(TeamType team);

        private void SubtractAmmo()
        {
            _ammoCount = Mathf.Max(InfiniteAmmo, _ammoCount - 1);

            if (!IsGunEmpty)
                return;

            Emptied?.Invoke();
            _entity.Destroy();
        }
    }
}