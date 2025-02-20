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

        public void Spawn(int damage, float speed, Transform point)
        {
            Bullet bullet = _bulletPool.Spawn(damage, speed, point);

            bullet.Destroyed += OnBulletDestroyed;
        }

        private void OnBulletDestroyed(Bullet bullet)
        {
            _bulletPool.Despawn(bullet);

            bullet.Destroyed -= OnBulletDestroyed;
        }
    }
}