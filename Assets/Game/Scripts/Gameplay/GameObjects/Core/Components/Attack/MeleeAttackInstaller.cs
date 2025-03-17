using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class MeleeAttackInstaller : MonoInstaller
    {
        [SerializeField] private MeleeAttackParams _attackParams;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MeleeAttackComponent>()
                .AsSingle()
                .WithArguments(_attackParams);

            Container.Bind<AbstractAttackComponent>()
                .To<MeleeAttackComponent>()
                .FromResolve();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (_attackParams.Point == null)
                return;

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_attackParams.Point.position, _attackParams.Radius);
        }
#endif
    }
}