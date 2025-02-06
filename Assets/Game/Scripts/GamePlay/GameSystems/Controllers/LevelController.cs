using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.Content.Player;
using Game.Core;
using Game.Core.Components;
using Game.Menu.Core;
using Game.Menu.UI;
using Game.View;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class LevelController : ILevelProgressTracker, ILevelRestarter, IInitializable, IDisposable
    {
        private readonly EndLevelView _endLevelTrigger;
        private readonly LevelMenuFactory _factory;
        private readonly MenuFacade _menu;

        private Canvas _canvas;

        public LevelController(LevelMenuFactory factory, MenuFacade menu, EndLevelView endLevelTrigger)
        {
            _endLevelTrigger = endLevelTrigger;
            _factory = factory;
            _menu = menu;
        }

        public event Action LevelRestarted;
        public event Action LevelCompleted;

        public void Initialize()
        {
            _canvas = _factory.Create();
            _canvas.worldCamera = Camera.main;
            _endLevelTrigger.LevelEnded += OnLevelEnded;
        }

        public void Dispose()
        {
            _endLevelTrigger.LevelEnded -= OnLevelEnded;
        }

        public void RestartLevel()
        {
            LevelRestarted?.Invoke();
        }

        private void OnLevelEnded(float delay)
        {
            LevelCompleted?.Invoke();
            DOTween.KillAll();
            EndLevel(delay).Forget();
        }

        private async UniTaskVoid EndLevel(float delay)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(delay));
            _menu.LoadNextLevel();
        }
    }
}