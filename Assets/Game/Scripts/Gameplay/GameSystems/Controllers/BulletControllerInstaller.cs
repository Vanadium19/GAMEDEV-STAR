using UnityEngine;
using Zenject;

namespace Game.GameSystems.Controllers
{
    public class BulletControllerInstaller : MonoInstaller
    {
        [SerializeField] private BulletCollisionController _controller;

        public override void InstallBindings()
        {
            Container.Bind<BulletCollisionController>()
                .FromInstance(_controller)
                .AsSingle();
        }
    }
}