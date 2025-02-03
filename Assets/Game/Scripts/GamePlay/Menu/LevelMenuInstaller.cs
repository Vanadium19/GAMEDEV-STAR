using Game.Menu.UI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Menu
{
    public class LevelMenuInstaller : MonoInstaller
    {
        [SerializeField] private LevelMenuView _levelMenuView;
        [SerializeField] private GameSettingsView _gameSettingsView;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LevelMenuPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<LevelMenuView>()
                .FromInstance(_levelMenuView)
                .AsSingle();

            Container.Bind<GameSettingsView>()
                .FromInstance(_gameSettingsView)
                .AsSingle();
        }
    }
}