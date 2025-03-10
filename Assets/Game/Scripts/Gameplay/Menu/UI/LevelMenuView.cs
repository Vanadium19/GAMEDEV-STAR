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
        [SerializeField] private Toggle _fpsToggle;

        [Header("Popups")] [SerializeField] private GameObject _menuPopup;
        [SerializeField] private GameObject _settingsPopup;
        [SerializeField] private GameObject _deathPopup;
        [SerializeField] private GameObject _endLevelPopup;
        [SerializeField] private GameObject _fpsCounter;

        public Observable<Unit> ContinueButtonClicked;
        public Observable<Unit> RestartButtonClicked;
        public Observable<Unit> ExitButtonClicked;
        public Observable<bool> FPSButtonPressed;

        private IDisposable _disposables;

        public void Initialize(bool showFPS)
        {
            _fpsToggle.isOn = showFPS;
            
            ContinueButtonClicked = _continueButton.OnClickAsObservable();
            RestartButtonClicked = _restartButton.OnClickAsObservable();
            ExitButtonClicked = _exitButtons.Select(button => button.OnClickAsObservable()).Merge();
            FPSButtonPressed = _fpsToggle.OnValueChangedAsObservable();
        }

        private void OnEnable()
        {
            var disposableBuilder = Disposable.CreateBuilder();

            _settingsButton.OnClickAsObservable()
                .Subscribe(_ => OpenSettingsPopup())
                .AddTo(ref disposableBuilder);

            ContinueButtonClicked.Subscribe(_ => _menuPopup.SetActive(false))
                .AddTo(ref disposableBuilder);
            
            FPSButtonPressed.Subscribe(_fpsCounter.SetActive)
                .AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        private void OnDisable()
        {
            _disposables?.Dispose();
        }

        public void OpenMenu()
        {
            _menuPopup.SetActive(true);
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