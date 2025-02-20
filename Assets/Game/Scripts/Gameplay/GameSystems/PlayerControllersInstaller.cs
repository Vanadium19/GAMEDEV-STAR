using Zenject;

namespace Game.Scripts.Gameplay.GameSystems
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
        }
    }
}