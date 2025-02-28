using Game.Core.Components;
using Game.GameSystems;
using UnityEngine;
using Zenject;

namespace Game.Content.Traps
{
    public class TrapInstaller : MonoInstaller
    {
        [Header("UnityComponents")]
        [SerializeField] private Transform _transform;
        [SerializeField] private CollisionController _collisionController;
        [Header("Parameters")]
        [SerializeField] private float _radius;
        [SerializeField] private int _damage;

        public override void InstallBindings()
        {
            BindTrap();
            BindTransform();
            BindAttackComponent();
            BindCollisionController();

        }

        private void BindCollisionController()
        {
            Container.Bind<CollisionController>()
                .FromInstance(_collisionController)
                .AsSingle();
        }

        private void BindAttackComponent()
        {
            Container.BindInterfacesAndSelfTo<ZoneAttackComponent>()
                .FromNew()
                .AsSingle()
                .WithArguments(_radius, _damage);
        }

        private void BindTrap()
        {
            Container.BindInterfacesAndSelfTo<Trap>()
                .AsSingle();
        }
        private void BindTransform()
        {
            Container.Bind<Transform>()
                .FromInstance(_transform)
                .AsSingle();
        }
    }
}
