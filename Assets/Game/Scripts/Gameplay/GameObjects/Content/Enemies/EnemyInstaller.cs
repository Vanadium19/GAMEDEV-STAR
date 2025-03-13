using Game.Core.Components;
using Game.Modules.Entities;
using Game.Scripts.Common;
using Game.View;
using R3;
using UnityEngine;
using Zenject;

namespace Game.Content.Enemies
{
    public class EnemyInstaller : MonoInstaller
    {
        [Header("Unity Components")][SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _transform;
        [SerializeField] private Entity _entity;

        [Header("Main Settings")][SerializeField] private int _health = 100;
        [SerializeField] private SerializableReactiveProperty<float> _moveSpeed = new(5f);
        [SerializeField] private SerializableReactiveProperty<float> _rotationSpeed = new(3f);
        [SerializeField] private TeamType _team = TeamType.Enemy;

        [Header("View")][SerializeField] private EnemyView _enemyView;

        public override void InstallBindings()
        {
            //Main
            Container.BindInterfacesAndSelfTo<Enemy>()
                .AsSingle()
                .NonLazy();

            //MonoBehaviors
            Container.BindInterfacesTo<Entity>()
                .FromInstance(_entity)
                .AsSingle();

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

            //View
            Container.BindInterfacesAndSelfTo<EnemyPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<EnemyView>()
                .FromInstance(_enemyView)
                .AsSingle();

        }
    }
}