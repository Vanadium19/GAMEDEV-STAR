using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu.UI
{
    public class LevelMenuView : MonoBehaviour
    {
        [SerializeField] private Button _openButton;
        [SerializeField] private Button _continueButton;
        [SerializeField] private GameObject _menuPopup;

        [SerializeField] private Button _exitButton;

        [SerializeField] private Button _settingsButton;
        [SerializeField] private GameObject _settingsPopup;

        private readonly ReactiveCommand _opened = new();
        private readonly ReactiveCommand _exited = new();
        private readonly ReactiveCommand _continued = new();
        private readonly CompositeDisposable _disposables = new();

        public IObservable<Unit> OpenButtonClicked => _opened;
        public IObservable<Unit> ExitButtonClicked => _exited;
        public IObservable<Unit> ContinueButtonClicked => _continued;

        private void OnEnable()
        {
            _opened.BindToOnClick(_openButton, (_) => _menuPopup.SetActive(true)).AddTo(_disposables);
            _continued.BindToOnClick(_continueButton, (_) => _menuPopup.SetActive(false)).AddTo(_disposables);
            _exited.BindTo(_exitButton).AddTo(_disposables);

            _settingsButton.onClick.AddListener(OnSettingsClicked);
        }

        private void OnDisable()
        {
            _settingsButton.onClick.RemoveListener(OnSettingsClicked);

            _disposables.Clear();
        }

        private void OnSettingsClicked()
        {
            _settingsPopup.SetActive(true);
        }
    }
}