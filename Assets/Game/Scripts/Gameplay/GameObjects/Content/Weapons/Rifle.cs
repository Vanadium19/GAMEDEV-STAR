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
        private readonly TeamType _team;
        private readonly float _speed;
        private readonly float _delay;
        private readonly int _damage;
        
        private int _ammoCount;
        private float _currentTime;

        public Rifle(BulletSpawner bulletSpawner,Transform transform,TeamType team,float speed, float delay, int damage, int maxAmmoCount)
        {
            _bulletSpawner = bulletSpawner;
            _shootPoint = transform;
            _team = team;
            _speed = speed;
            _delay = delay;
            _damage = damage;

            _ammoCount = maxAmmoCount;
        }

        public void Tick()
        {
            if (_currentTime > 0)
                _currentTime -= Time.deltaTime;
        }

        public void Shoot()
        {
            if (_currentTime > 0 || _ammoCount <= 0)
                return;
          
            _bulletSpawner.Spawn(_damage, _speed, _shootPoint,_team);
            _currentTime = _delay;
            _ammoCount -= 1;
        }
    }
}