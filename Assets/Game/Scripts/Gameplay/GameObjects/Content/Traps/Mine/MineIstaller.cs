using Zenject;
using UnityEngine;
using Game.Core.Components;
using Game.Scripts.Gameplay.GameSystems;

namespace Game.Content.Traps
{
    public class MineIstaller : MonoInstaller
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private MineCollisionController _mineCollisionController;
        [SerializeField] private float _radius;
        [SerializeField] private int _damage;

        public override void InstallBindings()
        {
            Container.Bind<Mine>()
                .AsSingle()
                .NonLazy();
           
            Container.Bind<Transform>()
                .FromInstance(_transform)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<ZoneAttackComponent>()
                .FromNew()
                .AsSingle()
                .WithArguments(_radius, _damage);

            Container.Bind<MineCollisionController>()
                .FromInstance(_mineCollisionController)
                .AsSingle();

                
        }

    }
}

