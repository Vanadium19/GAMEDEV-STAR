using Game.Menu.UI;
using UnityEngine;
using Zenject;

namespace Game.Menu
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private GameSettingsView _gameSettingsView;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MainMenuPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<MainMenuView>()
                .FromInstance(_mainMenuView)
                .AsSingle();

            Container.Bind<GameSettingsView>()
                .FromInstance(_gameSettingsView)
                .AsSingle();
        }
    }
}