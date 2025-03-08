using Zenject;
using UnityEngine;
using Game.Menu.UI;

namespace Game.Menu
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private GameSettingsView _settingsView;
        [SerializeField] private MainMenuView _menuView;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainMenuPresenter>()
                 .AsSingle()
                 .NonLazy();

            Container.Bind<GameSettingsView>()
                .FromInstance(_settingsView)
                .AsSingle();

            Container.Bind<MainMenuView>()
                .FromInstance(_menuView)
                .AsSingle(); 
        }
    }
}
