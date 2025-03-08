using System;
using System.Linq;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu.UI
{
    public class LevelMenuView : MonoBehaviour
    {
        [Header("Buttons")] [SerializeField] private Button[] _exitButtons;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _continueButton;

        [Header("Popups")] [SerializeField] private GameObject _menuPopup;
        [SerializeField] private GameObject _settingsPopup;
        [SerializeField] private GameObject _deathPopup;
        [SerializeField] private GameObject _endLevelPopup;

        public Observable<Unit> ContinueButtonClicked;
        public Observable<Unit> RestartButtonClicked;
        public Observable<Unit> ExitButtonClicked;

        private IDisposable _disposables;

        private void OnEnable()
        {
            var disposableBuilder = Disposable.CreateBuilder();

            _settingsButton.OnClickAsObservable()
                .Subscribe(_ => OpenSettingsPopup())
                .AddTo(ref disposableBuilder);

            ContinueButtonClicked.Subscribe(_ => _menuPopup.SetActive(false))
                .AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        public void OpenMenu()
        {
            _menuPopup.SetActive(true);
        }

        public void Initialize()
        {
            ContinueButtonClicked = _continueButton.OnClickAsObservable();
            RestartButtonClicked = _restartButton.OnClickAsObservable();
            ExitButtonClicked = _exitButtons.Select(button => button.OnClickAsObservable()).Merge();
        }

        public void OpenDeathMenu()
        {
            _deathPopup.SetActive(true);
        }

        public void OpenEndLevelPopup()
        {
            _endLevelPopup.SetActive(true);
        }

        private void OpenSettingsPopup()
        {
            _settingsPopup.SetActive(true);
            _menuPopup.SetActive(false);
        }
    }
}