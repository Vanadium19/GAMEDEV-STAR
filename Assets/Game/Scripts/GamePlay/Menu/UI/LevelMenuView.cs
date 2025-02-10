using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Menu.UI
{
    public class LevelMenuView : MonoBehaviour
    {
        [SerializeField] private Button _openButton;
        [SerializeField] private Button _continueButton;
        [SerializeField] private GameObject _menuPopup;

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;

        [SerializeField] private Button _settingsButton;
        [SerializeField] private GameObject _settingsPopup;

        private readonly ReactiveCommand _opened = new();
        private readonly ReactiveCommand _restarted = new();
        private readonly ReactiveCommand _exited = new();
        private readonly ReactiveCommand _continued = new();
        private readonly CompositeDisposable _disposables = new();

        public IObservable<Unit> OpenButtonClicked => _opened;
        public IObservable<Unit> RestartButtonClicked => _restarted;
        public IObservable<Unit> ExitButtonClicked => _exited;
        public IObservable<Unit> ContinueButtonClicked => _continued;

        private void OnEnable()
        {
            _opened.BindToOnClick(_openButton, (_) => OnOpenClicked()).AddTo(_disposables);
            _continued.BindToOnClick(_continueButton, (_) => OnContinueClicked()).AddTo(_disposables);
            _restarted.BindToOnClick(_restartButton, (_) => EventSystem.current.SetSelectedGameObject(null)).AddTo(_disposables);

            _exited.BindTo(_exitButton).AddTo(_disposables);

            _settingsButton.onClick.AddListener(OnSettingsClicked);
        }

        private void OnDisable()
        {
            _settingsButton.onClick.RemoveListener(OnSettingsClicked);

            _disposables.Clear();
        }

        private void OnOpenClicked()
        {
            _menuPopup.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
        }

        private void OnContinueClicked()
        {
            _menuPopup.SetActive(false);
            EventSystem.current.SetSelectedGameObject(null);
        }

        private void OnSettingsClicked()
        {
            _menuPopup.SetActive(false);
            _settingsPopup.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}