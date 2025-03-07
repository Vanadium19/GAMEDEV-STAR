using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu.UI
{
    public class MainMenuView : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingButton;
        [SerializeField] private Button _authorsButton;
        [SerializeField] private Button _exitButton;
        [Header("Panels")]
        [SerializeField] private GameObject _mainMenuPanel;
        [SerializeField] private GameObject _settingPanel;
        [SerializeField] private GameObject _authorsPanel;
        [SerializeField] private GameObject _levelSelectPanel;

        public Observable<Unit> PlayButtonPressed => _playButton.OnClickAsObservable();
        public Observable<Unit> ExitButtonPressed => _exitButton.OnClickAsObservable();

        //private ReactiveCommand _exitButtonPressed = new();
        //private ReactiveCommand _playButtonPressed = new();
        //private readonly CompositeDisposable _disposables = new();

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
            _settingButton.onClick.AddListener(OnSettingButtonPressed);
            _authorsButton.onClick.AddListener(OnAuthorsButtonPressed);
        }

        private void OnPlayButtonClicked()
        {
            _levelSelectPanel.SetActive(true);
        }

        private void OnDisable()
        {
            _settingButton.onClick.RemoveListener(OnSettingButtonPressed);
            _authorsButton.onClick.RemoveListener(OnAuthorsButtonPressed);
        }

        private void OnSettingButtonPressed()
        {
            _settingPanel.SetActive(true);
        }
        private void OnAuthorsButtonPressed()
        {
            _authorsPanel.SetActive(true);
        }
    }
}