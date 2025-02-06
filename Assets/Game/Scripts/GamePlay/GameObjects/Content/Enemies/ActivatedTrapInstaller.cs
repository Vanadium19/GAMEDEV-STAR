using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Enemies
{
    public class ActivatedTrapInstaller : MonoInstaller
    {
        private const string Tag = "Player";

        [SerializeField] private GameObject _trap;
        [SerializeField] private UnityEventReceiver _playerTracker;
        [SerializeField] private AudioSource _trapAudio;

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

            Container.Bind<AudioSource>()
                .FromInstance(_trapAudio)
                .AsSingle();

            Container.BindInterfacesTo<ActivatedTrap>()
                .AsSingle()
                .WithArguments(_delay, _trapTime)
                .NonLazy();
        }
    }
}