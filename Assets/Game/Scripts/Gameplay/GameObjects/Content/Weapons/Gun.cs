using Game.Content.Projectiles;
using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.Content.Weapons
{
    public class Gun : IWeapon, ITickable
    {
        private readonly BulletSpawner _bulletSpawner;
        private readonly Transform _shootPoint;
        private readonly TeamType _team;

        private readonly float _speed;
        private readonly float _delay;
        private readonly int _damage;

        private float _currentTime;

        public Gun(BulletSpawner bulletSpawner,
            Transform shootPoint,
            TeamType team,
            float speed,
            float delay,
            int damage)
        {
            _bulletSpawner = bulletSpawner;
            _shootPoint = shootPoint;
            _damage = damage;
            _team = team;
            _speed = speed;
            _delay = delay;
        }

        public void Tick()
        {
            if (_currentTime > 0)
                _currentTime -= Time.deltaTime;
        }

        public bool Shoot()
        {
            if (_currentTime > 0)
                return false;

            _bulletSpawner.Spawn(_damage, _speed, _shootPoint, _team);
            _currentTime = _delay;
            return true;
        }
    }
}