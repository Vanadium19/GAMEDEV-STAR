using DG.Tweening;
using UnityEngine;
using Game.Scripts.Common;
using R3;
using UnityEngine.SceneManagement;

namespace Game.Menu.Core
{
    public class MenuFacade : IVolumeSettings, ILevelLoader
    {
        private readonly LevelLoader _levelLoader;
        private readonly GameSettings _gameSettings;
        private readonly VolumeSettings _volumeSettings;

        private readonly Subject<Unit> _openMenuCommand = new();
        private readonly Subject<Unit> _openDeathPanelCommand = new();
        private readonly Subject<Unit> _openEndLevelPanelCommand = new();

        public MenuFacade(LevelLoader levelLoader,
            VolumeSettings volumeSettings,
            GameSettings gameSettings)
        {
            _levelLoader = levelLoader;
            _gameSettings = gameSettings;
            _volumeSettings = volumeSettings;
        }

        public float MusicVolume => _volumeSettings.MusicVolume;
        public float EffectsVolume => _volumeSettings.EffectsVolume;
        public bool ShowFPS => _gameSettings.ShowFPS;
        public Observable<Unit> OpenMenuCommand => _openMenuCommand;
        public Observable<Unit> OpenDeathPanelCommand => _openDeathPanelCommand;
        public Observable<Unit> OpenEndLevelPanelCommand => _openEndLevelPanelCommand;

        public void OpenMenu()
        {
            PauseGame();
            _openMenuCommand?.OnNext(Unit.Default);
        }

        public void OpenDeathPanel()
        {
            PauseGame();
            _openDeathPanelCommand?.OnNext(Unit.Default);
        }

        public void OpenEndLevelPanel()
        {
            _openEndLevelPanelCommand?.OnNext(Unit.Default);
        }

        public void LoadLevel()
        {
            ContinueGame();
            _levelLoader.LoadLevel();
        }

        public void LoadNextLevel()
        {
            _levelLoader.LoadNextLevel();
            _levelLoader.LoadLevel();
            //Save();
        }

        public void ShowFpsCounter(bool value)
        {
            _gameSettings.ShowFpsCounter(value);
            //Save();
        }

        public void SetMusicVolume(float volume)
        {
            _volumeSettings.SetMusicVolume(volume);
            //Save();
        }

        public void SetEffectsVolume(float volume)
        {
            _volumeSettings.SetEffectsVolume(volume);
            //Save();
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void ContinueGame()
        {
            Time.timeScale = 1;
        }

        public void ReturnToMainMenu()
        {
            ContinueGame();
            SceneManager.LoadScene((int)SceneNumber.Menu);
            DOTween.KillAll();
        }

        public void ExitGame()
        {
            DOTween.KillAll();
            Application.Quit();
        }
    }
}