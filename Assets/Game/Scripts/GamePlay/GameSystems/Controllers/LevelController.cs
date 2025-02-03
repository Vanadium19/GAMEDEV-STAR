using System;
using DG.Tweening;
using Game.Content.Player;
using Game.Core;
using Game.Core.Components;
using Game.Menu.Core;
using Game.Menu.UI;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class LevelController : ILevelProgressTracker, ILevelRestarter, IInitializable, IDisposable
    {
        private readonly TriggerTracker _endLevelTrigger;
        private readonly LevelMenuFactory _factory;
        private readonly MenuFacade _menu;

        private Canvas _canvas;

        public LevelController(LevelMenuFactory factory, MenuFacade menu, TriggerTracker endLevelTrigger)
        {
            _endLevelTrigger = endLevelTrigger;
            _factory = factory;
            _menu = menu;
        }

        public event Action LevelRestarted;

        public void Initialize()
        {
            _canvas = _factory.Create();
            _canvas.worldCamera = Camera.main;
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