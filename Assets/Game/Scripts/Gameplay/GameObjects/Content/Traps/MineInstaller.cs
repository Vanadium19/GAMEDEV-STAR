using Zenject;
using UnityEngine;
using Game.Core.Components;
using Game.GameSystems.Traps;
using Game.Modules.Entities;

namespace Game.Content.Traps
{
    public class MineInstaller : MonoInstaller
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Entity _entity;

        [SerializeField] private int _damage = 5;
        [SerializeField] private float _radius = 3f;
        [SerializeField] private float _delay = 1f;

        public override void InstallBindings()
        {
            //Main
            Container.BindInterfacesAndSelfTo<Mine>()
                .AsSingle()
                .NonLazy();

            //MonoBehaviors
            Container.Bind<Transform>()
                .FromInstance(_transform)
                .AsSingle();

            Container.BindInterfacesTo<Entity>()
                .FromInstance(_entity)
                .AsSingle();

            //Components
            Container.BindInterfacesAndSelfTo<ZoneAttackComponent>()
                .FromNew()
                .AsSingle()
                .WithArguments(_radius, _damage);

            Container.Decorate<IAttacker>()
                .With<DelayAttackDecorator>()
                .WithArguments(_delay);
        }
    }
}