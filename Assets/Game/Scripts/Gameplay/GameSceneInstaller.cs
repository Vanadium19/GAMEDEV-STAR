using Game.Content.Projectiles;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _bulletsContainer;

        public override void InstallBindings()
        {
            BulletsInstaller.Install(Container, _bulletPrefab, _bulletsContainer);
        }
    }
}