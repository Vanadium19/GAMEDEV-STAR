using Game.Components;
using Game.Obstacles.Enemies;
using UnityEngine;
using Zenject;

namespace Game.Obstacles.Installers
{
    public class TrapInstaller : MonoInstaller
    {
        private const int Damage = int.MaxValue;

        [SerializeField] private Trap _trap;
        [SerializeField] private UnityEventReceiver _unityEvents;

        public override void InstallBindings()
        {
            Container.Bind<Trap>()
                .FromInstance(_trap)
                .AsSingle();

            Container.Bind<UnityEventReceiver>()
                .FromInstance(_unityEvents)
                .AsSingle();

            Container.Bind<Attacker>()
                .AsSingle()
                .WithArguments(Damage);
        }
    }
}