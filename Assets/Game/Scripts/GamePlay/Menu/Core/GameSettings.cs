using UnityEngine;

namespace Game.Menu.Core
{
    public class GameSettings : IGameSettings
    {
        private float _volume;
        
        public float Volume => _volume;

        public void SetVolume(float volume)
        {
            _volume = volume;
            AudioListener.volume = volume;
        }
    }
}