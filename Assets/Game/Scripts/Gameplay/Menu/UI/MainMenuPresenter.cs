using System;
using R3;
using Zenject;
using Game.Menu.Core;

namespace Game.Menu.UI
{
    public class MainMenuPresenter : IInitializable, IDisposable
    {
        private const int DefaultValueCount = 1;

        private readonly MenuFacade _menuFacade;
        private readonly MainMenuView _menuView;

        private IDisposable _disposables;

        public MainMenuPresenter(MenuFacade menuFacade,
            MainMenuView menuView)
        {
            _menuFacade = menuFacade;
            _menuView = menuView;
        }

        public void Initialize()
        {
            _menuView.Initialize(_menuFacade.ShowFPS);

            var disposableBuilder = Disposable.CreateBuilder();

            _menuView.PlayButtonPressed.Subscribe(_ => _menuFacade.LoadLevel()).AddTo(ref disposableBuilder);
            _menuView.ExitButtonPressed.Subscribe(_ => _menuFacade.ExitGame()).AddTo(ref disposableBuilder);
            _menuView.FPSButtonPressed.Skip(DefaultValueCount).Subscribe(_menuFacade.ShowFpsCounter).AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }
    }
}