using Game.Content.Projectiles;
using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.Content.Weapons
{
    public class Gun : RangeWeapon, ITickable
    {
        private readonly BulletSpawner _bulletSpawner;
        private readonly Transform _shootPoint;
        private readonly TeamType _team;

        private readonly float _speed;
        private readonly float _delay;
        private readonly int _damage;

        private float _currentTime;

        public Gun(WeaponParams weaponParams, BulletSpawner bulletSpawner) : base(weaponParams.Handle)
        {
            _bulletSpawner = bulletSpawner;
            _shootPoint = weaponParams.ShootPoint;
            _damage = weaponParams.Damage;
            _team = weaponParams.Team;
            _speed = weaponParams.Speed;
            _delay = weaponParams.Delay;
        }

        public void Tick()
        {
            if (_currentTime > 0)
                _currentTime -= Time.deltaTime;
        }

        public override bool Shoot()
        {
            if (_currentTime > 0)
                return false;

            _bulletSpawner.Spawn(_damage, _speed, _shootPoint, _team);
            _currentTime = _delay;
            return true;
        }
    }
}