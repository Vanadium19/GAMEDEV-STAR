using Zenject;
using UnityEngine;
using Game.Menu.UI;

namespace Game.Menu
{
    public class MainMenuViewInstaller : Installer<MainMenuView, MainMenuViewInstaller>
    {
        private readonly MainMenuView _menuView;

        public MainMenuViewInstaller(MainMenuView menuView)
        {
            _menuView = menuView;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MainMenuPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<MainMenuView>()
                .FromInstance(_menuView)
                .AsSingle();
        }
    }
}