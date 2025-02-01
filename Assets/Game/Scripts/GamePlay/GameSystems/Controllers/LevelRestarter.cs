using System;
using Game.Content.Player;
using Game.Core;

namespace Game.Controllers
{
    public class LevelRestarter : ILevelProgressTracker, ILevelRestarter
    {
        public event Action LevelRestarted;

        public void RestartLevel()
        {
            LevelRestarted?.Invoke();
        }
    }
}