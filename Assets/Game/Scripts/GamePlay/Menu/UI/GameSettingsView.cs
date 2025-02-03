using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu.UI
{
    public class GameSettingsView : MonoBehaviour
    {
        [SerializeField] private Slider _volumeSlider;

        public event Action<float> VolumeChanged;

        private void OnEnable()
        {
            _volumeSlider.onValueChanged.AddListener(OnValueChanged);
        }

        private void Start()
        {
            _volumeSlider.value = AudioListener.volume;
        }

        private void OnDisable()
        {
            _volumeSlider.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(float volume)
        {
            VolumeChanged?.Invoke(volume);
        }
    }
}