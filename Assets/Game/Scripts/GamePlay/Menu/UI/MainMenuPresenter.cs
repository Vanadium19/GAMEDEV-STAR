using System;
using Game.Menu.Core;
using UniRx;
using Zenject;

namespace Game.Menu.UI
{
    public class MainMenuPresenter : IInitializable, IDisposable
    {
        private readonly MenuFacade _menuFacade;
        private readonly MainMenuView _menuView;
        private readonly GameSettingsView _gameSettingsView;
        private readonly CompositeDisposable _disposables = new();

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
            _menuView.PlayButtonPressed.Subscribe(unit =>  OnPlayButtonPressed()).AddTo(_disposables);
            _menuView.ExitButtonPressed.Subscribe(unit => _menuFacade.ExitGame()).AddTo(_disposables);
            
            _gameSettingsView.VolumeChanged += OnVolumeChanged;
        }

        public void Dispose()
        {
            _gameSettingsView.VolumeChanged -= OnVolumeChanged;
            
            _disposables.Dispose();
        }

        private void OnPlayButtonPressed()
        {
            _menuFacade.LoadGame();
        }

        private void OnVolumeChanged(float volume)
        {
            _menuFacade.SetVolume(volume);
        }
    }
}