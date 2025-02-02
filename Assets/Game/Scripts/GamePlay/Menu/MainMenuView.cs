using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _playButton;

        public event Action PlayButtonPressed;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayButtonPressed);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonPressed);
        }

        private void OnPlayButtonPressed()
        {
            PlayButtonPressed?.Invoke();
        }
    }
}