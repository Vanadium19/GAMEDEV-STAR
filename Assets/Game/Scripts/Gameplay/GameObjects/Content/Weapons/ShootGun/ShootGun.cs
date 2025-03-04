using Game.Content.Projectiles;
using Game.Scripts.Common;
using UnityEngine;
using System.Collections.Generic;
using Game.Modules.Entities;

namespace Game.Content.Weapons
{
    public class ShootGun : RangeWeapon
    {
        private readonly BulletSpawner _bulletSpawner;
        private readonly List<Transform> _shootPoints;

        private readonly float _speed;
        private readonly int _damage;

        public ShootGun(IEntity entity,
            WeaponParams weaponParams,
            BulletSpawner bulletSpawner,
            List<Transform> shootPoints)
            : base(entity, weaponParams.Handle, weaponParams.AmmoCount, weaponParams.Delay)
        {
            _bulletSpawner = bulletSpawner;
            _damage = weaponParams.Damage;
            _speed = weaponParams.Speed;
            _shootPoints = shootPoints;
        }

        protected override void SpawnBullet(TeamType team)
        {
            foreach (var shootPoint in _shootPoints)
                _bulletSpawner.Spawn(_damage, shootPoint.forward * _speed, shootPoint, team);
        }
    }
}