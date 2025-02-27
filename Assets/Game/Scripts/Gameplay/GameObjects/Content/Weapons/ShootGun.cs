using Game.Content.Projectiles;
using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.Content.Weapons
{
    public class ShootGun : IWeapon, ITickable
    {
        private readonly BulletSpawner _bulletSpawner;
        private readonly Transform _shootPoint;
        private readonly TeamType _team;

        private readonly float _speed;
        private readonly float _delay;
        private readonly int _maxAmmoCount;
        private readonly int _damage;

        private float _currentTime;
        private int _ammoCount;

        public ShootGun(BulletSpawner bulletSpawner,
            Transform shootPoint, TeamType teamType,
            float speed, float delay,
            int maxAmmoCount,int damage)
        {
            _bulletSpawner = bulletSpawner;
            _shootPoint = shootPoint;
            _team = teamType;
            _speed = speed;
            _delay = delay;
            _maxAmmoCount = maxAmmoCount;
            _damage = damage;

            _ammoCount = _maxAmmoCount;
        }

        public void Tick()
        {
            if(_currentTime > 0)
                _currentTime -= Time.deltaTime;
        }

        public void Shoot()
        {
            Quaternion rotation = _shootPoint.rotation;
            if (_currentTime > 0)
                return;
            //SpawnBulletWithOffSet(0);
            SpawnBulletWithOffSet(10);
            SpawnBulletWithOffSet(-10);
            SpawnBulletWithOffSet(20);
            SpawnBulletWithOffSet(-20);
            SpawnBulletWithOffSet(30);

            _currentTime = _delay;

            _shootPoint.rotation = rotation;
        }

        private void SpawnBulletWithOffSet(float offset)
        {
            _bulletSpawner.Spawn(_damage, _speed, _shootPoint, _team);
            _shootPoint.rotation = Quaternion.Euler(_shootPoint.rotation.x, offset, _shootPoint.rotation.z);
        }

    }
}

