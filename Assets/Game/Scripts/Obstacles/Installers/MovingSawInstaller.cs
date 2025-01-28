using Game.Components;
using Game.Obstacles.Enemies;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Obstacles.Installers
{
    public class MovingSawInstaller : MonoInstaller
    {
        private const int Damage = int.MaxValue;

        [SerializeField] private Saw _saw;
        [SerializeField] private Transform _transform;

        [Header("Movement")] [SerializeField] private float _speed = 2;

        [Header("Attack")] [SerializeField] private UnityEventReceiver _unityEvents;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Saw>()
                .FromInstance(_saw)
                .AsSingle();

            Container.Bind<TransformMover>()
                .AsSingle()
                .WithArguments(_transform, _speed);

            Container.Bind<UnityEventReceiver>()
                .FromInstance(_unityEvents)
                .AsSingle();

            Container.Bind<Attacker>()
                .AsSingle()
                .WithArguments(Damage);
        }
    }
}