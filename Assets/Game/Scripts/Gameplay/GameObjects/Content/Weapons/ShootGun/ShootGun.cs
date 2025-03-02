using Game.Content.Projectiles;
using Game.Scripts.Common;
using UnityEngine;
using System.Collections.Generic;
using Zenject;

namespace Game.Content.Weapons
{
    public class ShootGun : RangeWeapon, ITickable
    {
        private readonly BulletSpawner _bulletSpawner;
        private readonly List<Transform> _shootPoints;

        private readonly int _ammoCount;
        private readonly float _speed;
        private readonly float _delay;
        private readonly int _damage;

        private float _currentTime;

        public ShootGun(WeaponParams weaponParams,
            BulletSpawner bulletSpawner,
            int maxAmmoCount, List<Transform> shootPoints)
            : base(weaponParams.Handle)
        {
            _bulletSpawner = bulletSpawner;

            _damage = weaponParams.Damage;
            _speed = weaponParams.Speed;
            _delay = weaponParams.Delay;
            _shootPoints = shootPoints;

            _ammoCount = maxAmmoCount;
        }

        public void Tick()
        {
            if (_currentTime > 0)
                _currentTime -= Time.deltaTime;
        }

        public override bool Shoot(TeamType team, out int shootedAmmoCount)
        {
            shootedAmmoCount = 0;
            
            if (_currentTime > 0 || Mathf.Max(_ammoCount, 0) == 0)
                return false;

            foreach(var shootPoint in _shootPoints)
            {
                _bulletSpawner.Spawn(_damage, _speed * shootPoint.forward, shootPoint, team);
                shootedAmmoCount += 1;
            }

            _currentTime = _delay;
            return true;
        }
    }
}