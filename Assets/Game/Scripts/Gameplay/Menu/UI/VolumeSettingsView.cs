using System;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu.UI
{
    public class VolumeSettingsView : MonoBehaviour
    {
        [SerializeField] private Slider _musicVolumeSlider;
        [SerializeField] private Slider _effectVolumeSlider;

        private ReactiveProperty<float> _musicVolume;
        private ReactiveProperty<float> _effectVolume;

        public ReadOnlyReactiveProperty<float> MusicVolume => _musicVolume;
        public ReadOnlyReactiveProperty<float> EffectVolume => _effectVolume;

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

        public void Initialize(float musicVolume, float effectVolume)
        {
            _musicVolume = new ReactiveProperty<float>(musicVolume);
            _effectVolume = new ReactiveProperty<float>(effectVolume);

            _musicVolumeSlider.value = musicVolume;
            _effectVolumeSlider.value = effectVolume;
        }

        private void OnMusicVolumeChanged(float volume)
        {
            _musicVolume.Value = volume;
        }

        private void OnEffectVolumeChanged(float volume)
        {
            _effectVolume.Value = volume;
        }
    }
}