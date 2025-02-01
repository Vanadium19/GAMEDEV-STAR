using System;
using DG.Tweening;
using Game.Content.Player;
using Game.Core;
using Game.Core.Components;
using Game.Menu;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class LevelController : ILevelProgressTracker, ILevelRestarter, IInitializable, IDisposable
    {
        private readonly TriggerTracker _endLevelTrigger;
        private readonly MenuFacade _menu;

        public LevelController(MenuFacade menu, TriggerTracker endLevelTrigger)
        {
            _menu = menu;
            _endLevelTrigger = endLevelTrigger;
        }

        public event Action LevelRestarted;

        public void Initialize()
        {
            _endLevelTrigger.Entered += FinishLevel;
        }

        public void Dispose()
        {
            _endLevelTrigger.Entered -= FinishLevel;
        }

        public void RestartLevel()
        {
            LevelRestarted?.Invoke();
        }

        private void FinishLevel(Collider2D player)
        {
            _menu.LoadNextLevel();
            DOTween.KillAll();
        }
    }
}