using Game.Scripts.Common;
using UnityEngine;
using UnityEngine.Audio;

namespace Game.Menu.Core
{
    public class VolumeSettings : IVolumeSettings
    {
        private readonly AudioMixer _mixer;

        private float _musicVolume = 1;
        private float _effectsVolume = 1;

        public VolumeSettings(AudioMixer mixer)
        {
            _mixer = mixer;
        }

        public float MusicVolume => _musicVolume;
        public float EffectsVolume => _effectsVolume;

        public void SetEffectsVolume(float volume)
        {
            _effectsVolume = volume;
            SetVolume(AudioParams.SFXVolume, volume);
        }

        public void SetMusicVolume(float volume)
        {
            _musicVolume = volume;
            SetVolume(AudioParams.MusicVolume, volume);
        }

        private void SetVolume(string name, float volume)
        {
            float newVolume = volume == 0
                ? AudioParams.ZeroVolume
                : Mathf.Lerp(AudioParams.MinVolume, AudioParams.MaxVolume, volume);

            _mixer.SetFloat(name, newVolume);
        }
    }
}