using Game.Components;
using Game.Obstacles.Enemies;
using UnityEngine;
using Zenject;

namespace Game.Obstacles.Installers
{
    public class ActivatedTrapInstaller : MonoInstaller
    {
        private const string Tag = "Player";

        [SerializeField] private GameObject _trap;
        [SerializeField] private UnityEventReceiver _playerTracker;

        [SerializeField] private float _delay = 0.5f;
        [SerializeField] private float _trapTime = 3f;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TriggerTracker>()
                .AsSingle()
                .WithArguments(_playerTracker, new[] { Tag });

            Container.Bind<GameObject>()
                .FromInstance(_trap)
                .AsSingle();

            Container.BindInterfacesTo<ActivatedTrap>()
                .AsSingle()
                .WithArguments(_delay, _trapTime)
                .NonLazy();
        }
    }
}