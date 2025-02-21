using Game.Core.Components;
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
        [SerializeField] private float _attackDelay = 1f;
        [SerializeField] private SerializableReactiveProperty<float> _moveSpeed = new(5f);

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

            Container.BindInterfacesAndSelfTo<HealthComponent>()
                .AsSingle()
                .WithArguments(_health);

            Container.BindInterfacesAndSelfTo<MeleeAttackComponent>()
                .AsSingle()
                .WithArguments(_attackDelay);
        }
    }
}