using UnityEngine;
using Zenject;

namespace Game.Content.Projectiles
{
    public class BulletsInstaller : Installer<Bullet, Transform, BulletsInstaller>
    {
        private const string BulletName = "Bullet";

        private readonly Bullet _bulletPrefab;
        private readonly Transform _container;

        public BulletsInstaller(Bullet bulletPrefab, Transform container)
        {
            _bulletPrefab = bulletPrefab;
            _container = container;
        }

        public override void InstallBindings()
        {
            Container.BindMemoryPool<Bullet, BulletPool>()
                .ExpandByOneAtATime()
                .FromComponentInNewPrefab(_bulletPrefab)
                .WithGameObjectName(BulletName)
                .UnderTransform(_container)
                .AsSingle();

            Container.Bind<BulletSpawner>()
                .AsSingle()
                .NonLazy();
        }
    }
}