using System;
using Game.Menu.Core;
using R3;
using Zenject;

namespace Game.Menu.UI
{
    public class LevelMenuPresenter : IInitializable, IDisposable
    {
        private readonly MenuFacade _menuFacade;
        private readonly LevelMenuView _view;

        private IDisposable _disposables;

        public LevelMenuPresenter(MenuFacade menuFacade, LevelMenuView view)
        {
            _menuFacade = menuFacade;
            _view = view;
        }

        public void Initialize()
        {
            var disposableBuilder = Disposable.CreateBuilder();

            _menuFacade.OpenMenuCommand.Subscribe(_ => _view.OpenMenu()).AddTo(ref disposableBuilder);
            _menuFacade.OpenDeathPanelCommand.Subscribe(_ => _view.OpenDeathMenu()).AddTo(ref disposableBuilder);

            _view.ExitButtonClicked.Subscribe(_ => _menuFacade.ReturnToMainMenu()).AddTo(ref disposableBuilder);
            _view.RestartButtonClicked.Subscribe(_ => _menuFacade.LoadGame()).AddTo(ref disposableBuilder);
            _view.ContinueButtonClicked.Subscribe(_ => _menuFacade.ContinueGame()).AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }
    }
}