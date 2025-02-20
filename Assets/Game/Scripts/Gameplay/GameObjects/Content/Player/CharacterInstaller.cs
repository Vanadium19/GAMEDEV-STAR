using Game.Core.Components;
using R3;
using UnityEngine;
using Zenject;

namespace Game.Content.Player
{
    public class CharacterInstaller : MonoInstaller
    {
        [Header("Unity Components")] [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _transform;

        [Header("Main Settings")] [SerializeField] private int _health = 100;
        [SerializeField] private SerializableReactiveProperty<float> _moveSpeed = new(3f);
        [SerializeField] private SerializableReactiveProperty<float> _rotationSpeed = new(3f);

        public override void InstallBindings()
        {
            //Main
            Container.BindInterfacesAndSelfTo<Character>()
                .AsSingle()
                .NonLazy();

            //MonoBehaviors
            Container.Bind<Rigidbody>()
                .FromInstance(_rigidbody)
                .AsSingle();

            Container.Bind<Transform>()
                .FromInstance(_transform)
                .AsSingle();

            //Components
            Container.BindInterfacesAndSelfTo<MoveComponent>()
                .AsSingle()
                .WithArguments(_moveSpeed);

            Container.BindInterfacesAndSelfTo<RotationComponent>()
                .AsSingle()
                .WithArguments(_rotationSpeed);

            Container.BindInterfacesAndSelfTo<HealthComponent>()
                .AsSingle()
                .WithArguments(_health);

            Container.BindInterfacesAndSelfTo<AttackComponent>()
                .AsSingle();
        }
    }
}