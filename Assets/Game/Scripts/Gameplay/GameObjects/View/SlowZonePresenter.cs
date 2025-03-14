using Game.Core.Components;
using R3;
using System;
using Zenject;

namespace Game.View
{
    public class SlowZonePresenter : IInitializable, IDisposable
    {
        private readonly IHealth _health;
        private readonly SlowZoneView _view;

        private IDisposable _disposables;
        
        public SlowZonePresenter(IHealth health, SlowZoneView view)
        {
            _health = health;
            _view = view;
        }

        public void Initialize()
        {
            var disposableBuilder = Disposable.CreateBuilder();
            _health.IsDead.Subscribe(OnDeathStatusChanged).AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }

        private void OnDeathStatusChanged(bool value)
        {
            _view.OnSlowZoneDeathStatusChanged(value);
        }
    }
}
