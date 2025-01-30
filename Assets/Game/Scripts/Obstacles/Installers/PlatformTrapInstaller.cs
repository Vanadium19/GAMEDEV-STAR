using Game.Components;
using Game.Obstacles.Enemies;
using UnityEngine;
using Zenject;

namespace Game.Obstacles.Installers
{
    public class PlatformTrapInstaller : MonoInstaller
    {
        private const string Tag = "Player";

        [SerializeField] private UnityEventReceiver _unityEvents;
        [SerializeField] private GameObject _platform;

        [SerializeField] private float _delay = 1f;

        public override void InstallBindings()
        {
            Container.Bind<UnityEventReceiver>()
                .FromInstance(_unityEvents)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<CollisionTracker>()
                .AsSingle()
                .WithArguments(new[] { Tag });

            Container.Bind<GameObjectSwitcher>()
                .AsSingle()
                .WithArguments(_platform, _delay);

            Container.BindInterfacesTo<PlatformTrap>()
                .AsSingle()
                .NonLazy();
        }
    }
}