using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Content.Enemies;
using Game.Content.Player;
using Game.Core.Components;
using Game.Menu.Core;
using Game.Menu.UI;
using R3;
using UnityEngine;
using Zenject;

namespace Game.GameSystems.Controllers
{
    public class LevelProgressController : IInitializable, IDisposable
    {
        private const float LevelFinishDelay = 1.5f;

        private readonly LevelMenuFactory _menuFactory;
        private readonly MenuFacade _menu;

        private readonly CharacterProvider _character;
        private readonly EnemiesCounter _enemiesCounter;

        private readonly CancellationTokenSource _cancellationToken = new();

        private IDisposable _disposables;

        public LevelProgressController(LevelMenuFactory menuFactory,
            CharacterProvider character,
            EnemiesCounter enemiesCounter,
            MenuFacade menu)
        {
            _menuFactory = menuFactory;
            _menu = menu;

            _character = character;
            _enemiesCounter = enemiesCounter;
        }

        public void Initialize()
        {
            _menuFactory.Create();

            var disposableBuilder = Disposable.CreateBuilder();

            _character.Get<IHealth>()
                .IsDead.Where(value => value)
                .Subscribe(_ => _menu.OpenDeathPanel())
                .AddTo(ref disposableBuilder);

            _enemiesCounter.CurrentEnemiesCount.Where(count => count == 0)
                .Subscribe(_ => FinishLevel().Forget())
                .AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        public void Dispose()
        {
            _disposables?.Dispose();
            _cancellationToken.Cancel();
            _cancellationToken.Dispose();
        }

        private async UniTaskVoid FinishLevel()
        {
            _menu.OpenEndLevelPanel();

            await UniTask.Delay(TimeSpan.FromSeconds(LevelFinishDelay), cancellationToken: _cancellationToken.Token);

            _menu.LoadNextLevel();
        }
    }
}