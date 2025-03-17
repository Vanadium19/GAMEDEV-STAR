using System;
using Game.Menu.Core;
using R3;
using Zenject;

namespace Game.Menu.UI
{
    public class LevelMenuPresenter : IInitializable, IDisposable
    {
        private const int DefaultValueCount = 1;

        private readonly MenuFacade _menuFacade;
        private readonly LevelMenuView _view;

        private readonly ICursorChanger _cursorChanger;

        private IDisposable _disposables;

        public LevelMenuPresenter(MenuFacade menuFacade, LevelMenuView view, ICursorChanger cursorChanger)
        {
            _menuFacade = menuFacade;
            _view = view;
            _cursorChanger = cursorChanger;
        }

        public void Initialize()
        {
            _cursorChanger.SetAimCursor();
            _view.Initialize(_menuFacade.ShowFPS);

            var disposableBuilder = Disposable.CreateBuilder();

            _menuFacade.OpenMenuCommand.Subscribe(_ => OpenMenu()).AddTo(ref disposableBuilder);
            _menuFacade.OpenDeathPanelCommand.Subscribe(_ => _view.OpenDeathMenu()).AddTo(ref disposableBuilder);
            _menuFacade.OpenEndLevelPanelCommand.Subscribe(_ => _view.OpenEndLevelPopup()).AddTo(ref disposableBuilder);

            _view.ExitButtonClicked.Subscribe(_ => _menuFacade.ReturnToMainMenu()).AddTo(ref disposableBuilder);
            _view.RestartButtonClicked.Subscribe(_ => _menuFacade.LoadLevel()).AddTo(ref disposableBuilder);
            _view.ContinueButtonClicked.Subscribe(_ => ContinueGame()).AddTo(ref disposableBuilder);
            _view.FPSButtonPressed.Skip(DefaultValueCount).Subscribe(_menuFacade.ShowFpsCounter).AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }

        private void OpenMenu()
        {
            _view.OpenMenu();
            _cursorChanger.SetDefaultCursor();
        }

        private void ContinueGame()
        {
            _menuFacade.ContinueGame();
            _cursorChanger.SetAimCursor();
        }
    }
}