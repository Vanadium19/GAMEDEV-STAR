using Game.Menu;
using Game.Menu.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class MenuSceneInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuView _menuView;
        [SerializeField] private VolumeSettingsView _volumeSettingsView;

        public override void InstallBindings()
        {
            MainMenuViewInstaller.Install(Container, _menuView);
            VolumeSettingsViewInstaller.Install(Container, _volumeSettingsView);
        }
    }
}