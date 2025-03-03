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

        private readonly float _speed;
        private readonly float _delay;
        private readonly int _damage;

        private float _currentTime;

        public ShootGun(WeaponParams weaponParams,
            BulletSpawner bulletSpawner, List<Transform> shootPoints)
            : base(weaponParams.Handle, weaponParams.AmmoCount)
        {
            _bulletSpawner = bulletSpawner;
            _damage = weaponParams.Damage;
            _speed = weaponParams.Speed;
            _delay = weaponParams.Delay;
            _shootPoints = shootPoints;
        }

        public void Tick()
        {
            if (_currentTime > 0)
                _currentTime -= Time.deltaTime;
        }

        protected override int SpawnBullet(TeamType team)
        {
            int shootedAmmo = 0;

            if (_currentTime > 0 || IsGunEmpty())
                return shootedAmmo;

            foreach(var shootPoint in _shootPoints)
            {
                _bulletSpawner.Spawn(_damage, shootPoint.forward * _speed, shootPoint, team);
                shootedAmmo++;
            }

            _currentTime = _delay;
            return shootedAmmo;
        }
    }
}