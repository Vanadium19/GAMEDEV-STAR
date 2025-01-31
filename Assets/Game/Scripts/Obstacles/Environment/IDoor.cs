using System;

namespace Game.Obstacles.Environment
{
    public interface IDoor
    {
        public event Action<int> KeyCountChanged;
        public event Action Opened;
        public event Action Closed;

        public int KeyCount { get; }
    }
}