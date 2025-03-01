using Zenject;
using UnityEngine;
using Game.Core.Components;
using Game.GameSystems.Traps;

namespace Game.Content.Traps
{
    public class MineInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _transform;

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
            Container.Bind<GameObject>()
                .FromInstance(_gameObject)
                .AsSingle();

            Container.Bind<Transform>()
                .FromInstance(_transform)
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