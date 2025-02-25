using Game.Core.Components;
using Game.Scripts.Common;
using R3;
using UnityEngine;
using Zenject;

namespace Game.Content.Enemies
{
    public class EnemyInstaller : MonoInstaller
    {
        [Header("Unity Components")] [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _transform;

        [Header("Main Settings")] [SerializeField] private int _health = 100;
        [SerializeField] private SerializableReactiveProperty<float> _moveSpeed = new(5f);
        [SerializeField] private SerializableReactiveProperty<float> _rotationSpeed = new(3f);
        [SerializeField] private TeamType _team = TeamType.Enemy;
        // [SerializeField] private float _attackDelay = 1f;

        public override void InstallBindings()
        {
            //Main
            Container.BindInterfacesAndSelfTo<Enemy>()
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

            Container.Bind<TeamType>()
                .FromInstance(_team)
                .AsSingle();

            // Container.BindInterfacesAndSelfTo<MeleeAttackComponent>()
            //     .AsSingle()
            //     .WithArguments(_attackDelay);

            Container.BindInterfacesAndSelfTo<AttackComponent>()
                .AsSingle();
        }
    }
}