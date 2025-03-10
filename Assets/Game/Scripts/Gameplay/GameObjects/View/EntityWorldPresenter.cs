using System;
using Game.Content.Enemies;
using R3;
using Zenject;

namespace Game.View
{
    public class EntityWorldPresenter : IInitializable, IDisposable
    {
        private readonly EnemiesCounter _enemiesCounter;
        private readonly EnemiesCountView _view;

        private IDisposable _disposables;

        public EntityWorldPresenter(EnemiesCounter enemiesCounter, EnemiesCountView view)
        {
            _enemiesCounter = enemiesCounter;
            _view = view;
        }

        public void Initialize()
        {
            var disposableBuilder = Disposable.CreateBuilder();

            _enemiesCounter.CurrentEnemiesCount.Subscribe(OnEnemiesCountChanged).AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }

        private void OnEnemiesCountChanged(int count)
        {
            string text = $"{_enemiesCounter.MaxEnemiesCount - count}/{_enemiesCounter.MaxEnemiesCount}";

            _view.ShowEnemiesCount(text);
        }
    }
}