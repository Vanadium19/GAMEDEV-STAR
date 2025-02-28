using System;
using Game.Core.Components;
using Game.UI;
using R3;
using Zenject;

namespace Game.View
{
    public class PlayerPresenter : IInitializable, IDisposable
    {
        private readonly IDamagable _health;
        private readonly HealthView _heathView;

        private IDisposable _disposables;

        public PlayerPresenter(IDamagable health, HealthView heathView)
        {
            _health = health;
            _heathView = heathView;
        }

        public void Initialize()
        {
            var disposableBuilder = Disposable.CreateBuilder();

            _health.CurrentHealth.Subscribe(OnHealthChanged).AddTo(ref disposableBuilder);

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
    }
}