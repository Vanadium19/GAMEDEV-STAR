using Game.Components;
using Game.Obstacles.Enemies;
using UnityEngine;
using Zenject;

namespace Game.Obstacles.Installers
{
    public class TrapInstaller : MonoInstaller
    {
        private const string Tag = "Player";
        private const int Damage = int.MaxValue;

        [SerializeField] private UnityEventReceiver _unityEvents;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Trap>()
                .AsSingle()
                .NonLazy();

            Container.Bind<UnityEventReceiver>()
                .FromInstance(_unityEvents)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<TriggerTracker>()
                .AsSingle()
                .WithArguments(new[] { Tag });

            Container.Bind<Attacker>()
                .AsSingle()
                .WithArguments(Damage);
        }
    }
}