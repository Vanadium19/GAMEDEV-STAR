using Zenject;

namespace Game.Core.Components
{
    public class RangeAttackInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RangeAttackComponent>()
                .AsSingle()
                .NonLazy();
        }
    }
}