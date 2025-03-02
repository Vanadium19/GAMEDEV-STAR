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

        private int _ammoCount;
        private float _currentTime;

        public Rifle(WeaponParams weaponParams, BulletSpawner bulletSpawner, int maxAmmoCount)
            : base(weaponParams.Handle)
        {
            _bulletSpawner = bulletSpawner;
            _shootPoint = weaponParams.ShootPoint;
            _damage = weaponParams.Damage;
            _speed = weaponParams.Speed;
            _delay = weaponParams.Delay;

            _ammoCount = maxAmmoCount;
        }

        public void Tick()
        {
            if (_currentTime > 0)
                _currentTime -= Time.deltaTime;
        }

        public override bool Shoot(TeamType team, out int shootedAmmoCount)
        {
            if (_currentTime > 0 || Mathf.Max(_ammoCount, 0) == 0)
            {
                shootedAmmoCount = 0;
                return false;
            }

            _bulletSpawner.Spawn(_damage, _speed * _shootPoint.forward, _shootPoint, team);
            _currentTime = _delay;
            shootedAmmoCount = 1;
            return true;
        }

    }
}