using UnityEngine;
using Zenject;

namespace Game.GameSystems.Traps
{
    public class BarrelCollisionControllerInstaller : MonoInstaller
    {
        [SerializeField] private BarrelCollisionController _controller;

        public override void InstallBindings()
        {
            Container.Bind<BarrelCollisionController>()
                .FromInstance(_controller)
                .AsSingle()
                .NonLazy();
        }
    }
}