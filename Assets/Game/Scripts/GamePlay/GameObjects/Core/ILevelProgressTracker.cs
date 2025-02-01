using System;

namespace Game.Core
{
    public interface ILevelProgressTracker
    {
        public event Action LevelRestarted;
    }
}