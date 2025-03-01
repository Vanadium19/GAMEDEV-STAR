using Game.Content.Projectiles;
using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.Content.Weapons
{
    public class ShootGun : RangeWeapon, ITickable
    {
        private readonly BulletSpawner _bulletSpawner;
        private readonly Transform _shootPoint;
        private readonly TeamType _team;

        private readonly int _ammoCount;
        private readonly float _speed;
        private readonly float _delay;
        private readonly int _damage;

        private float _currentTime;

        public ShootGun(WeaponParams weaponParams,
            BulletSpawner bulletSpawner,
            int maxAmmoCount)
            : base(weaponParams.Handle)
        {
            _bulletSpawner = bulletSpawner;
            _shootPoint = weaponParams.ShootPoint;
            _damage = weaponParams.Damage;
            _team = weaponParams.Team;
            _speed = weaponParams.Speed;
            _delay = weaponParams.Delay;

            _ammoCount = maxAmmoCount;
        }

        public void Tick()
        {
            if (_currentTime > 0)
                _currentTime -= Time.deltaTime;
        }

        public override bool Shoot()
        {
            Quaternion rotation = _shootPoint.rotation;

            if (_currentTime > 0 || _ammoCount <= 0)
                return false;

            SpawnBulletWithOffSet(10);
            SpawnBulletWithOffSet(-10);
            SpawnBulletWithOffSet(20);
            SpawnBulletWithOffSet(-20);
            SpawnBulletWithOffSet(30);

            _currentTime = _delay;

            _shootPoint.rotation = rotation;
            return true;
        }

        private void SpawnBulletWithOffSet(float offset)
        {
            _bulletSpawner.Spawn(_damage, _speed, _shootPoint, _team);
            _shootPoint.rotation = Quaternion.Euler(_shootPoint.rotation.x, offset, _shootPoint.rotation.z);
        }
    }
}