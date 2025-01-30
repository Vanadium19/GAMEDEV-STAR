using System;

namespace Game.Components
{
    public interface ILevelProgressTracker
    {
        public event Action LevelRestarted;
    }
}