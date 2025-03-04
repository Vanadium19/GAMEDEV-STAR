using System;
using Game.GameObjects;
using R3;
using Zenject;

namespace Game.View
{
    public class EntityWorldPresenter : IInitializable, IDisposable
    {
        private readonly EntityWorld _entityWorld;
        private readonly EnemiesCountView _view;

        private IDisposable _disposables;

        public EntityWorldPresenter(EntityWorld entityWorld, EnemiesCountView view)
        {
            _entityWorld = entityWorld;
            _view = view;
        }

        public void Initialize()
        {
            var disposableBuilder = Disposable.CreateBuilder();

            _entityWorld.CurrentEnemiesCount.Subscribe(OnEnemiesCountChanged).AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }

        private void OnEnemiesCountChanged(int count)
        {
            string text = $"Осталось врагов {count}";

            _view.ShowEnemiesCount(text);
        }
    }
}