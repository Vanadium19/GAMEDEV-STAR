using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Enemies
{
    public class PlatformTrapInstaller : MonoInstaller
    {
        private const string Tag = "Player";

        [SerializeField] private UnityEventReceiver _playerTracker;
        [SerializeField] private GameObject _platform;

        [SerializeField] private float _delay = 1f;

        public override void InstallBindings()
        {
            Container.Bind<GameObject>()
                .FromInstance(_platform)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<CollisionTracker>()
                .AsSingle()
                .WithArguments(_playerTracker, new[] { Tag });

            Container.BindInterfacesTo<PlatformTrap>()
                .AsSingle()
                .WithArguments(_delay)
                .NonLazy();
        }
    }
}