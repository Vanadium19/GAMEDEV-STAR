using Game.Content.Projectiles;
using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.Content.Weapons
{
    public class Rifle : IWeapon, ITickable
    {
        private readonly BulletSpawner _bulletSpawner;
        private readonly Transform _shootPoint;

        private readonly float _speed;
        private readonly float _delay;
        private readonly int _maxAmmoCount;
        private readonly int _damage;
        
        private int _ammoCount;
        private float _currentTime;

        public Rifle(BulletSpawner bulletSpawner,Transform transform,float speed, float delay, int damage, int maxAmmoCount)
        {
            _bulletSpawner = bulletSpawner;
            _shootPoint = transform;
            _speed = speed;
            _delay = delay;
            _maxAmmoCount = maxAmmoCount;
            _damage = damage;

            _ammoCount = _maxAmmoCount;
        }

        public void Tick()
        {
            if (_currentTime > 0)
                _currentTime -= Time.deltaTime;
        }

        public bool Shoot()
        {
            if (_currentTime > 0 || _ammoCount <= 0)
                return false;
          
            _bulletSpawner.Spawn(_damage, _speed, _shootPoint, TeamType.Default);
            _currentTime = _delay;
            _ammoCount -= 1;
            Debug.Log($"�������� �������� : {_ammoCount}");
            return true;
        }
    }
}

