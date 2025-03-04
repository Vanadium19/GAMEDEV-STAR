using Cysharp.Threading.Tasks;
using Game.Content.Projectiles;
using Game.Scripts.Common;
using System;
using UnityEngine;

namespace Game.Content.Weapons
{
    public class Pistol : RangeWeapon, IReloadable
    {
        public event Action Reloading;
        
        private readonly BulletSpawner _bulletSpawner;
        private readonly Transform _shootPoint;

        private readonly float _speed;
        private readonly int _damage;

        private readonly int _maxReloadAmmo;
        private int _remainsReloadAmmo;
        private bool _isReloading;

        public Pistol(WeaponParams weaponParams,
            BulletSpawner bulletSpawner,
            int maxReloadAmmo)
            : base(weaponParams.Handle, weaponParams.AmmoCount, weaponParams.Delay)
        {
            _bulletSpawner = bulletSpawner;
            _shootPoint = weaponParams.ShootPoint;
            _damage = weaponParams.Damage;
            _speed = weaponParams.Speed;
            _maxReloadAmmo = maxReloadAmmo;
            _remainsReloadAmmo = maxReloadAmmo;
        }

        protected override void SpawnBullet(TeamType team)
        {
            if (_remainsReloadAmmo <= 0)
            {
                Reload();
                return;
            }

            if (_isReloading)
                return;

            _bulletSpawner.Spawn(_damage, _shootPoint.forward * _speed, _shootPoint, team);
            _remainsReloadAmmo--;
        }

        public void Reload()
        {
            if (_isReloading)
                return;

            ReloadAsync().Forget();
        }

        private async UniTaskVoid ReloadAsync()
        {
            _isReloading = true;

            Reloading?.Invoke();
            
            await UniTask.Delay(TimeSpan.FromSeconds(2));
           
            _remainsReloadAmmo = _maxReloadAmmo;
            _isReloading = false;
        }

        public bool IsAmmoFull() => _remainsReloadAmmo >= _maxReloadAmmo;
    }
}
