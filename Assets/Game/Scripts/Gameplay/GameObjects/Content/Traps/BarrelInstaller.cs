using Game.Core.Components;
using Game.Modules.Entities;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Content.Traps
{
    public class BarrelInstaller : MonoInstaller
    {
        [FormerlySerializedAs("_gameObject")] [SerializeField] private Entity _entity;
        [SerializeField] private GameObject _barrel;
        [SerializeField] private GameObject _fire;
        [SerializeField] private Transform _transform;

        [SerializeField] private int _damage = 5;
        [SerializeField] private float _radius = 3f;
        [SerializeField] private float _fireTime = 2f;

        public override void InstallBindings()
        {
            //Main
            Container.BindInterfacesAndSelfTo<Barrel>()
                .AsSingle()
                .WithArguments(_barrel, _fire, _fireTime)
                .NonLazy();

            //MonoBehaviors
            Container.BindInterfacesTo<Entity>()
                .FromInstance(_entity)
                .AsSingle();

            Container.Bind<Transform>()
                .FromInstance(_transform)
                .AsSingle();

            //Components
            Container.BindInterfacesAndSelfTo<ZoneAttackComponent>()
                .AsSingle()
                .WithArguments(_radius, _damage)
                .NonLazy();
        }
    }
}