using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Core;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Enemies
{
    public class PlatformTrap : IInitializable, IDisposable
    {
        private readonly ILevelProgressTracker _levelTracker;
        private readonly CollisionTracker _tracker;
        private readonly GameObject _platform;
        private readonly float _delay;

        private CancellationTokenSource _resetToken;

        public PlatformTrap(ILevelProgressTracker levelTracker,
            CollisionTracker tracker,
            GameObject platform,
            float delay)
        {
            _levelTracker = levelTracker;
            _tracker = tracker;
            _delay = delay;
            _platform = platform;
        }

        public void Initialize()
        {
            _tracker.Entered += OnEntered;
            _levelTracker.LevelRestarted += ResetPlatform;
        }

        public void Dispose()
        {
            _tracker.Entered -= OnEntered;
            _levelTracker.LevelRestarted -= ResetPlatform;
            
            _resetToken?.Cancel();
            _resetToken?.Dispose();
        }

        private void OnEntered(Collider2D target)
        {
            _resetToken = new CancellationTokenSource();

            DisablePlatform().Forget();
        }

        private async UniTask DisablePlatform()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken: _resetToken.Token);

            _platform.SetActive(false);
        }

        private void ResetPlatform()
        {
            _resetToken?.Cancel();
            _platform.SetActive(true);
        }
    }
}