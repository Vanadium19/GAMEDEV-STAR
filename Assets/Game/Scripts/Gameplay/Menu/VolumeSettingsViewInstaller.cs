using Game.Menu.UI;
using Zenject;

namespace Game.Menu
{
    public class VolumeSettingsViewInstaller : Installer<VolumeSettingsView, VolumeSettingsViewInstaller>
    {
        private readonly VolumeSettingsView _volumeView;

        public VolumeSettingsViewInstaller(VolumeSettingsView volumeView)
        {
            _volumeView = volumeView;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<VolumeSettingsPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<VolumeSettingsView>()
                .FromInstance(_volumeView)
                .AsSingle();
        }
    }
}