using System;
using Game.Core.Components;
using Game.UI;
using R3;
using Zenject;

namespace Game.View
{
    public class PlayerPresenter : IInitializable, IDisposable
    {
        private readonly IHealth _health;
        private readonly IMovable _movable;
        private readonly HealthView _heathView;
        private readonly PlayerView _playerView;

        private IDisposable _disposables;

        public PlayerPresenter(IHealth health,
            HealthView heathView,
            IMovable movable,
            PlayerView playerView)
        {
            _health = health;
            _heathView = heathView;
            _movable = movable;
            _playerView = playerView;
        }

        public void Initialize()
        {
            var disposableBuilder = Disposable.CreateBuilder();

            _health.CurrentHealth.Subscribe(OnHealthChanged).AddTo(ref disposableBuilder);
            _health.IsDead.Where(value => value).Subscribe(OnDeath).AddTo(ref disposableBuilder);
            _movable.IsMoving.Subscribe(OnMove).AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }

        private void OnHealthChanged(int health)
        {
            _heathView.SetHealth(health, _health.MaxHealth);
        }

        private void OnMove(bool value)
        {
            _playerView.OnPlayerMove(value);
        }

        private void OnDeath(bool value)
        {
            _playerView.OnPlayerDie(value);
        }
    }
}