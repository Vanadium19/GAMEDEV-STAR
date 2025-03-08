using DG.Tweening;
using UnityEngine;
using Game.Scripts.Common;
using R3;
using UnityEngine.SceneManagement;

namespace Game.Menu.Core
{
    public class MenuFacade
    {
        private readonly ILevelLoader _levelLoader;

        private readonly Subject<Unit> _openMenuCommand = new();
        private readonly Subject<Unit> _openDeathPanelCommand = new();
        private readonly Subject<Unit> _openEndLevelPanelCommand = new();

        public MenuFacade(ILevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }

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

        public void LoadGame()
        {
            ContinueGame();
            _levelLoader.LoadLevel();
        }

        public void LoadNextLevel()
        {
            _levelLoader.SetNextLevel();
            _levelLoader.LoadLevel();
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