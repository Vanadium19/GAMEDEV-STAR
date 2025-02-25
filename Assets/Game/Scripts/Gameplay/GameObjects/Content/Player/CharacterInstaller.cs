using Game.Core.Components;
using Game.Scripts.Common;
using Game.UI;
using Game.View;
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
        [SerializeField] private TeamType _team = TeamType.Player;

        [Header("View")] [SerializeField] private HealthView _healthView;

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

            Container.Bind<TeamType>()
                .FromInstance(_team)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<AttackComponent>()
                .AsSingle();

            //Presenter
            Container.BindInterfacesTo<PlayerPresenter>()
                .AsSingle()
                .NonLazy();

            //View
            Container.Bind<HealthView>()
                .FromInstance(_healthView)
                .AsSingle();
        }
    }
}