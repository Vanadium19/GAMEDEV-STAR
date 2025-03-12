using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class ZoneAttackInstaller : MonoInstaller
    {
        [SerializeField] private int _damage = 5;
        [SerializeField] private float _radius = 3f;
        [SerializeField] private float _delay = 1f;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ZoneAttackComponent>()
                .AsSingle()
                .WithArguments(_radius, _damage)
                .NonLazy();

            Container.Decorate<IAttacker>()
                .With<DelayAttackDecorator>()
                .WithArguments(_delay);

            Container.Bind<ZoneAttackComponent>().To<ZoneAttackComponent>()
                .FromResolve();
        }
    }
}