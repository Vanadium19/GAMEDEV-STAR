using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Enemies
{
    public class TrapInstaller : MonoInstaller
    {
        private const string Tag = "Player";
        private const int Damage = int.MaxValue;

        [SerializeField] private UnityEventReceiver _playerTracker;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Trap>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<TriggerTracker>()
                .AsSingle()
                .WithArguments(_playerTracker, new[] { Tag });

            Container.Bind<Attacker>()
                .AsSingle()
                .WithArguments(Damage);
        }
    }
}