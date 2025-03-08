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

        [Header("Panels")] [SerializeField] private GameObject _settingPanel;
        [SerializeField] private GameObject _authorsPanel;
        [SerializeField] private GameObject _levelSelectPanel;

        public Observable<Unit> PlayButtonPressed;
        public Observable<Unit> ExitButtonPressed;

        private IDisposable _disposables;

        private void Awake()
        {
            PlayButtonPressed = _playButton.OnClickAsObservable();
            ExitButtonPressed = _exitButton.OnClickAsObservable();
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

            _disposables = disposableBuilder.Build();
        }

        private void OnDisable()
        {
            _disposables.Dispose();
        }
    }
}