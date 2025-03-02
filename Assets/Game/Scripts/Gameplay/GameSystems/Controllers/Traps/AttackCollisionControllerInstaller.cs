using UnityEngine;
using Zenject;

namespace Game.GameSystems.Traps
{
    public class AttackCollisionControllerInstaller : MonoInstaller
    {
        [SerializeField] private AttackCollisionController _controller;

        public override void InstallBindings()
        {
            Container.Bind<AttackCollisionController>()
                .FromInstance(_controller)
                .AsSingle()
                .NonLazy();
        }
    }
}