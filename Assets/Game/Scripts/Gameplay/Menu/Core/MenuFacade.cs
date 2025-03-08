using System;
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

        public MenuFacade(ILevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }

        public Observable<Unit> OpenMenuCommand => _openMenuCommand;

        public void OpenMenu()
        {
            PauseGame();
            _openMenuCommand?.OnNext(Unit.Default);
        }

        public void LoadGame()
        {
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