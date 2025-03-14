using Zenject;
using System;
using Game.Core.Components;
using R3;

namespace Game.View
{
    public class EnemyPresenter : IInitializable, IDisposable
    {
        private readonly IHealth _health;
        private readonly IMovable _movable;
        private readonly EnemyView _enemyView;

        private IDisposable _disposables;

        public EnemyPresenter(IHealth health,
            IMovable movable,
            EnemyView enemyView)
        {
            _health = health;
            _movable = movable;
            _enemyView = enemyView;
        }

        public void Initialize()
        {      
            var disposableBuilder = Disposable.CreateBuilder();
            _health.IsDead.Where(value => value).Subscribe(OnDie).AddTo(ref disposableBuilder);
            _movable.IsMoving.Subscribe(OnMoving).AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }
        
        public void Dispose()
        {
            _disposables?.Dispose();
        }

        private void OnDie(bool value)
        {
            _enemyView.OnEnemyDie(value);
        }

        private void OnMoving(bool value)
        {
            _enemyView.OnEnenmyWalk(value);
        }
    }
}