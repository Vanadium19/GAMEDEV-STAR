using DG.Tweening;
using UnityEngine;
using Game.Scripts.Common;
using UnityEngine.SceneManagement;

namespace Game.Menu.Core
{
    public class MenuFacade
    {
        private readonly IGameSettings _gameSettings;
        private readonly ILevelLoader _levelLoader;

        public MenuFacade(IGameSettings gameSettings,
            ILevelLoader levelLoader)
        {
            _gameSettings = gameSettings;
            _levelLoader = levelLoader;
        }

        public void LoadGame()
        {
            _levelLoader.LoadLevel();
        }

        public void SetMusicVolume(float volume)
        {
            _gameSettings.SetMusicVolume(volume);
        }

        public void SetEffectVolume(float volume)
        {
            _gameSettings.SetEffectsVolume(volume);
        }

        public void LoadNextLevel()
        {
            _levelLoader.SetNextLevel();
            _levelLoader.LoadLevel();
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
            SceneManager.LoadScene((int)SceneNumbers.Menu);
            DOTween.KillAll();
        }

        public void ExitGame()
        {
            DOTween.KillAll();
            Application.Quit();
        }
    }   
}