using System;
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
        private readonly CompositeDisposable _disposables = new();

        public LevelMenuPresenter(MenuFacade menuFacade,
            LevelMenuView menuView,
            GameSettingsView gameSettingsView)
        {
            _menuFacade = menuFacade;
            _menuView = menuView;
            _gameSettingsView = gameSettingsView;
        }

        public void Initialize()
        {
            _menuView.ContinueButtonClicked.Subscribe(unit =>  _menuFacade.ContinueGame()).AddTo(_disposables);
            _menuView.OpenButtonClicked.Subscribe(unit =>  _menuFacade.PauseGame()).AddTo(_disposables);
            _menuView.ExitButtonClicked.Subscribe(unit => _menuFacade.ReturnToMainMenu()).AddTo(_disposables);
            
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