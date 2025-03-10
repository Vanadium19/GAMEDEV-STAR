using UnityEngine;

namespace Game.Menu.Core
{
    public class GameSettings
    {
        private bool _showFPS;

        public bool ShowFPS => _showFPS;

        public void ShowFpsCounter(bool value)
        {
            Debug.Log($"ShowFPS: {value}");
            _showFPS = value;
        }
    }
}