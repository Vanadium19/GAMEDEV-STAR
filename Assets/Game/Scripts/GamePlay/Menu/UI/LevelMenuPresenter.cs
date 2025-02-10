using System;
using Game.Controllers;
using Game.Menu.Core;
using UniRx;
using Zenject;

namespace Game.Menu.UI
{
    public class LevelMenuPresenter : IInitializable, IDisposable
    {
        private readonly MenuFacade _menuFacade;
        private readonly LevelMenuView _menuView;
        private readonly GameSettingsView _gameSettingsView;
        private readonly LevelController _restarter;
        
        private readonly CompositeDisposable _disposables = new();

        public LevelMenuPresenter(MenuFacade menuFacade,
            LevelMenuView menuView,
            GameSettingsView gameSettingsView,
            LevelController restarter)
        {
            _menuFacade = menuFacade;
            _menuView = menuView;
            _gameSettingsView = gameSettingsView;
            _restarter = restarter;
        }

        public void Initialize()
        {
            _menuView.ContinueButtonClicked.Subscribe(_ =>  _menuFacade.ContinueGame()).AddTo(_disposables);
            _menuView.OpenButtonClicked.Subscribe(_ =>  _menuFacade.PauseGame()).AddTo(_disposables);
            _menuView.ExitButtonClicked.Subscribe(_ => _menuFacade.ReturnToMainMenu()).AddTo(_disposables);
            _menuView.RestartButtonClicked.Subscribe(_ => _restarter.RestartLevel()).AddTo(_disposables);
            
            _gameSettingsView.VolumeChanged += OnVolumeChanged;
        }

        public void Dispose()
        {
            _gameSettingsView.VolumeChanged -= OnVolumeChanged;
            
            _disposables.Dispose();
        }

        private void OnVolumeChanged(float volume)
        {
            _menuFacade.SetVolume(volume);
        }
    }
}