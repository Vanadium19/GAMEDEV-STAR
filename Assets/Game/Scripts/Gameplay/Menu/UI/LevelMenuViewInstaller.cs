using UnityEngine;
using Zenject;

namespace Game.Menu.UI
{
    public class LevelMenuViewInstaller : MonoInstaller
    {
        [SerializeField] private LevelMenuView _menuView;
        [SerializeField] private VolumeSettingsView _volumeSettingsView;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LevelMenuPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<LevelMenuView>()
                .FromInstance(_menuView)
                .AsSingle();

            VolumeSettingsViewInstaller.Install(Container, _volumeSettingsView);
        }
    }
}