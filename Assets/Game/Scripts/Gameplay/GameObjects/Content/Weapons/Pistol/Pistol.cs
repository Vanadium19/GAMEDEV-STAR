using Game.Content.Projectiles;
using Game.Modules.Entities;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Content.Weapons
{
    public class Pistol : RangeWeapon
    {
        private readonly BulletSpawner _bulletSpawner;
        private readonly Transform _shootPoint;

        private readonly float _speed;
        private readonly int _damage;

        public Pistol(IEntity entity,
            WeaponParams weaponParams,
            BulletSpawner bulletSpawner)
            : base(entity, weaponParams.Handle, weaponParams.AmmoCount, weaponParams.Delay)
        {
            _bulletSpawner = bulletSpawner;
            _shootPoint = weaponParams.ShootPoint;
            _damage = weaponParams.Damage;
            _speed = weaponParams.Speed;
        }

        protected override void SpawnBullet(TeamType team)
        {
            _bulletSpawner.Spawn("Bullet", _damage, _shootPoint.forward * _speed, _shootPoint, team);
        }
    }
}