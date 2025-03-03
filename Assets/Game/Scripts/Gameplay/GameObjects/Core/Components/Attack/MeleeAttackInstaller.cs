using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class MeleeAttackInstaller : MonoInstaller
    {
        [SerializeField] private float _attackDelay = 1f;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MeleeAttackComponent>()
                .AsSingle()
                .WithArguments(_attackDelay);
        }
    }
}