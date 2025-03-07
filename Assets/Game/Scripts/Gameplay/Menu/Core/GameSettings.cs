using UnityEngine;

namespace Game.Menu.Core
{
    public class GameSettings : IGameSettings
    {
        public float MusicVolume => _musicVolume;
        public float EffectsVolume => _effectsVolume;

        private float _musicVolume = 1;
        private float _effectsVolume = 1;
        
        public void SetEffectsVolume(float volume)
        {
            _effectsVolume = volume;
            AudioListener.volume = volume;
        }

        public void SetMusicVolume(float volume)
        {
            _musicVolume = volume;
            AudioListener.volume = volume;
        }
    }
}