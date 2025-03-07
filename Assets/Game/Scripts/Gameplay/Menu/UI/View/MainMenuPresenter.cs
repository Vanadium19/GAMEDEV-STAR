using R3;
using Zenject;
using Game.Menu.Core;

namespace Game.Menu.UI
{
    public class MainMenuPresenter : IInitializable, ILateDisposable
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
            //_menuView.PlayButtonPressed.Subscribe(unit => OnPlayButtonPressed()).AddTo(_disposables);
            _menuView.ExitButtonPressed.Subscribe(unit => _menuFacade.ExitGame()).AddTo(_disposables);

            _gameSettingsView.MusicVolumeChanged += OnMusicVolumeChanged;
            _gameSettingsView.EffectVolumeChanged += OnEffectVolumeChanged;
        }

        public void LateDispose()
        {
            Dispose();
        }

        public void Dispose()
        {
            _gameSettingsView.MusicVolumeChanged -= OnMusicVolumeChanged;
            _gameSettingsView.EffectVolumeChanged -= OnEffectVolumeChanged;

            _disposables.Dispose();
        }

        private void OnPlayButtonPressed()
        {
            _menuFacade.LoadGame();
        }

        private void OnMusicVolumeChanged(float volume)
        {
            _menuFacade.SetMusicVolume(volume);
        }

        private void OnEffectVolumeChanged(float volume)
        {
            _menuFacade.SetEffectVolume(volume);
        }
    }
}
