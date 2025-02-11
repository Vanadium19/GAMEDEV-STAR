using System;
using Game.Core;
using UnityEngine;
using Zenject;

namespace Game.View
{
    public class СongratulationPopup : IInitializable, IDisposable
    {
        private readonly ILevelProgressTracker _progressTracker;
        private readonly GameObject _popup;

        public СongratulationPopup(ILevelProgressTracker progressTracker, GameObject popup)
        {
            _progressTracker = progressTracker;
            _popup = popup;
        }

        public void Initialize()
        {
            _progressTracker.LevelCompleted += OnLevelCompleted;
        }

        public void Dispose()
        {
            _progressTracker.LevelCompleted -= OnLevelCompleted;
        }

        private void OnLevelCompleted()
        {
            _popup.SetActive(true);
        }
    }
}