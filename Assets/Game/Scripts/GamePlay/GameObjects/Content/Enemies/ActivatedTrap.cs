using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Core;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Enemies
{
    public class ActivatedTrap : IInitializable, IDisposable
    {
        private readonly ILevelProgressTracker _levelTracker;
        private readonly TriggerTracker _playerTracker;
        private readonly AudioSource _trapSound;
        private readonly GameObject _trap;

        private readonly float _delay;
        private readonly float _trapTime;

        private bool _isActive;
        private CancellationTokenSource _resetToken;

        public ActivatedTrap(ILevelProgressTracker levelTracker,
            TriggerTracker playerTracker,
            AudioSource trapSound,
            GameObject trap,
            float delay,
            float trapTime)
        {
            _playerTracker = playerTracker;
            _levelTracker = levelTracker;
            _trapSound = trapSound;
            _trap = trap;
            _delay = delay;
            _trapTime = trapTime;
        }

        public void Initialize()
        {
            _levelTracker.LevelRestarted += OnLevelRestarted;
            _playerTracker.Entered += OnEntered;
            _trap.SetActive(false);
        }

        public void Dispose()
        {
            _playerTracker.Entered -= OnEntered;
            _levelTracker.LevelRestarted -= OnLevelRestarted;

            _resetToken?.Cancel();
            _resetToken?.Dispose();
        }

        private async UniTaskVoid Activate()
        {
            _isActive = true;
            await UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken: _resetToken.Token);

            _trapSound.Play();
            _trap.SetActive(true);

            await UniTask.Delay(TimeSpan.FromSeconds(_trapTime), cancellationToken: _resetToken.Token);

            _trap.SetActive(false);
            _isActive = false;
        }

        private void OnEntered(Collider2D tracker)
        {
            if (_isActive)
                return;

            _resetToken = new CancellationTokenSource();
            Activate().Forget();
        }

        private void OnLevelRestarted()
        {
            _resetToken?.Cancel();
            
            _trap.SetActive(false);
            _isActive = false;
        }
    }
}