using Zenject;

namespace Game.Controllers
{
    public class CharacterControllersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoveController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<JumpController>()
                .AsSingle()
                .NonLazy();
        }
    }
}