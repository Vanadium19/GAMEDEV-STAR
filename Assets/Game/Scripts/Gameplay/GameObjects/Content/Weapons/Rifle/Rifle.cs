using Game.Content.Projectiles;
using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.Content.Weapons
{
    public class Rifle : RangeWeapon, ITickable
    {
        private readonly BulletSpawner _bulletSpawner;
        private readonly Transform _shootPoint;
        private readonly float _speed;
        private readonly float _delay;
        private readonly int _damage;

        private float _currentTime;

        public Rifle(WeaponParams weaponParams, BulletSpawner bulletSpawner)
            : base(weaponParams.Handle, weaponParams.AmmoCount)
        {
            _bulletSpawner = bulletSpawner;
            _shootPoint = weaponParams.ShootPoint;
            _damage = weaponParams.Damage;
            _speed = weaponParams.Speed;
            _delay = weaponParams.Delay;
        }

        public void Tick()
        {
            if (_currentTime > 0)
                _currentTime -= Time.deltaTime;
        }

        protected override int SpawnBullet(TeamType team)
        {
            if (_currentTime > 0 || IsGunEmpty())
                return 0;

            _bulletSpawner.Spawn(_damage, _shootPoint.forward * _speed, _shootPoint, team);
            return 1;
        }
    }
}