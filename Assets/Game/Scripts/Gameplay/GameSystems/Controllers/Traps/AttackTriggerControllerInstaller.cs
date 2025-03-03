using UnityEngine;
using Zenject;

namespace Game.GameSystems.Traps
{
    public class AttackTriggerControllerInstaller : MonoInstaller
    {
        [SerializeField] private AttackTriggerController _controller;

        public override void InstallBindings()
        {
            Container.Bind<AttackTriggerController>()
                .FromInstance(_controller)
                .AsSingle()
                .NonLazy();
        }
    }
}