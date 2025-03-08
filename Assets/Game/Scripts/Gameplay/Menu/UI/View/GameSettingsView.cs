using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu.UI
{
    public class GameSettingsView : MonoBehaviour
    {
        [SerializeField] private Slider _musicVolumeSlider;
        [SerializeField] private Slider _effectVolumeSlider;

        public Action<float> MusicVolumeChanged;
        public Action<float> EffectVolumeChanged;

        private void OnEnable()
        {
            _musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
            _effectVolumeSlider.onValueChanged.AddListener(OnEffectVolumeChanged);
        }

        private void OnDisable()
        {
            _musicVolumeSlider.onValueChanged.RemoveListener(OnMusicVolumeChanged);
            _effectVolumeSlider.onValueChanged.RemoveListener(OnEffectVolumeChanged);
        }

        private void OnMusicVolumeChanged(float volume)
        {
            MusicVolumeChanged?.Invoke(volume);
        }

        private void OnEffectVolumeChanged(float volume)
        {
            EffectVolumeChanged?.Invoke(volume);
        }
    }
}