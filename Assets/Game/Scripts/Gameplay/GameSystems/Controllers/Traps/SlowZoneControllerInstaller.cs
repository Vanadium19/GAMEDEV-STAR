using UnityEngine;
using Zenject;

namespace Game.GameSystems.Traps
{
    public class SlowZoneControllerInstaller : MonoInstaller
    {
        [SerializeField] private SlowZoneCollisionController _controller;

        public override void InstallBindings()
        {
            Container.Bind<SlowZoneCollisionController>()
                .FromInstance(_controller)
                .AsSingle()
                .NonLazy();
        }
    }
}