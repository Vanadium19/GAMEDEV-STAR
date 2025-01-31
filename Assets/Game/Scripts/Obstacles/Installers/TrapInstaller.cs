using Game.Components;
using Game.Obstacles.Enemies;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Obstacles.Installers
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