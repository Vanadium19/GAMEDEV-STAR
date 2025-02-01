using System;
using Zenject;

namespace Game.Menu
{
    public class MainMenuPresenter : IInitializable, IDisposable
    {
        private readonly MenuFacade _menuFacade;
        private readonly MainMenuView _menuView;
        private readonly GameSettingsView _gameSettingsView;

        public MainMenuPresenter(MenuFacade menuFacade,
            MainMenuView menuView,
            GameSettingsView gameSettingsView)
        {
            _menuFacade = menuFacade;
            _menuView = menuView;
            _gameSettingsView = gameSettingsView;
        }

        public void Initialize()
        {
            _menuView.PlayButtonPressed += OnOnPlayButtonPressed;
            _gameSettingsView.VolumeChanged += OnVolumeChanged;
        }

        public void Dispose()
        {
            _menuView.PlayButtonPressed -= OnOnPlayButtonPressed;
            _gameSettingsView.VolumeChanged -= OnVolumeChanged;
        }

        private void OnOnPlayButtonPressed()
        {
            _menuFacade.LoadGame();
        }

        private void OnVolumeChanged(float volume)
        {
            _menuFacade.SetVolume(volume);
        }
    }
}