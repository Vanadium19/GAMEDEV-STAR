using System;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu.UI
{
    public class MainMenuView : MonoBehaviour
    {
        [Header("Buttons")] [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingButton;
        [SerializeField] private Button _authorsButton;
        [SerializeField] private Button _levelsButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Toggle _fpsToggle;

        [Header("Panels")] [SerializeField] private GameObject _settingPanel;
        [SerializeField] private GameObject _authorsPanel;
        [SerializeField] private GameObject _levelSelectPanel;
        [SerializeField] private GameObject _fpsCounter;

        public Observable<Unit> PlayButtonPressed;
        public Observable<Unit> ExitButtonPressed;
        public Observable<bool> FPSButtonPressed;

        private IDisposable _disposables;

        public void Initialize(bool showFPS)
        {
            _fpsToggle.isOn = showFPS;
        }

        private void Awake()
        {
            PlayButtonPressed = _playButton.OnClickAsObservable();
            ExitButtonPressed = _exitButton.OnClickAsObservable();
            FPSButtonPressed = _fpsToggle.OnValueChangedAsObservable();
        }

        private void OnEnable()
        {
            var disposableBuilder = Disposable.CreateBuilder();

            _settingButton.OnClickAsObservable()
                .Subscribe(_ => _settingPanel.SetActive(true))
                .AddTo(ref disposableBuilder);

            _authorsButton.OnClickAsObservable()
                .Subscribe(_ => _authorsPanel.SetActive(true))
                .AddTo(ref disposableBuilder);

            _levelsButton.OnClickAsObservable()
                .Subscribe(_ => _levelSelectPanel.SetActive(true))
                .AddTo(ref disposableBuilder);

            FPSButtonPressed.Subscribe(_fpsCounter.SetActive)
                .AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        private void OnDisable()
        {
            _disposables.Dispose();
        }
    }
}