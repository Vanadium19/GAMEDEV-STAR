using UnityEngine;
using Zenject;

namespace Game.GameSystems.Traps
{
    public class InteractableAreaControllerInstaller : MonoInstaller
    {
        [SerializeField] private InteractableAreaCollisionController _controller;

        public override void InstallBindings()
        {
            Container.Bind<InteractableAreaCollisionController>()
                .FromInstance(_controller)
                .AsSingle()
                .NonLazy();
        }
    }
}