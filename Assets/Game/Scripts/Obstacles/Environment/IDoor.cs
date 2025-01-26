using System;

namespace Game.Obstacles.Environment
{
    public interface IDoor
    {
        public event Action Opened;
    }
}