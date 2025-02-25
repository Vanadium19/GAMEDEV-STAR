using Game.Scripts.Common;
using UnityEngine;

namespace Game.Content.Projectiles
{
    public class BulletSpawner
    {
        private readonly BulletPool _bulletPool;

        public BulletSpawner(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }

        public void Spawn(int damage, float speed, Transform point, TeamType team)
        {
            Bullet bullet = _bulletPool.Spawn(damage, speed, point, team);

            bullet.Destroyed += OnBulletDestroyed;
        }

        private void OnBulletDestroyed(Bullet bullet)
        {
            _bulletPool.Despawn(bullet);

            bullet.Destroyed -= OnBulletDestroyed;
        }
    }
}