using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu.UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        [SerializeField] private Button _settingButton;
        [SerializeField] private GameObject _settingsPopup;

        [SerializeField] private Button _authorsButton;
        [SerializeField] private GameObject _authorsPopup;

        private readonly ReactiveCommand _exitButtonPressed = new();
        private readonly ReactiveCommand _playButtonPressed = new();
        private readonly CompositeDisposable _disposables = new();

        public IObservable<Unit> PlayButtonPressed => _playButtonPressed;
        public IObservable<Unit> ExitButtonPressed => _exitButtonPressed;

        private void OnEnable()
        {
            _exitButtonPressed.BindTo(_exitButton).AddTo(_disposables);
            _playButtonPressed.BindTo(_playButton).AddTo(_disposables);

            _settingButton.onClick.AddListener(OnSettingsButtonPressed);
            _authorsButton.onClick.AddListener(OnAuthorsButtonPressed);
        }

        private void OnDisable()
        {
            _settingButton.onClick.RemoveListener(OnSettingsButtonPressed);
            _authorsButton.onClick.RemoveListener(OnAuthorsButtonPressed);

            _disposables.Clear();
        }

        private void OnSettingsButtonPressed()
        {
            _settingsPopup.SetActive(true);
        }

        private void OnAuthorsButtonPressed()
        {
            _authorsPopup.SetActive(true);
        }
    }
}