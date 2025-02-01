using UnityEngine;

namespace Game.Menu
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