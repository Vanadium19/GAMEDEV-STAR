using UnityEngine;

namespace Game.Menu.Core
{
    public class VolumeSettings : IVolumeSettings
    {
        private float _musicVolume = 1;
        private float _effectsVolume = 1;

        public float MusicVolume => _musicVolume;
        public float EffectsVolume => _effectsVolume;

        public void SetEffectsVolume(float volume)
        {
            Debug.Log($"Effects volume: {volume}");
            _effectsVolume = volume;
            AudioListener.volume = volume;
        }

        public void SetMusicVolume(float volume)
        {
            Debug.Log($"Music volume: {volume}");
            _musicVolume = volume;
            AudioListener.volume = volume;
        }
    }
}