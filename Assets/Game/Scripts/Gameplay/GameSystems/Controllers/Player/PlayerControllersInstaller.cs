using Zenject;

namespace Game.GameSystems.Player
{
    public class PlayerControllersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerMoveController>()
                .AsSingle()
                .NonLazy();
            
            Container.BindInterfacesTo<PlayerRotateController>()
                .AsSingle()
                .NonLazy();
            
            Container.BindInterfacesTo<PlayerAttackController>()
                .AsSingle()
                .NonLazy();
        }
    }
}