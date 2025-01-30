using System;
using Game.Components;
using Game.Player;

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