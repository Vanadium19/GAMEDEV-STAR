using UnityEngine;

namespace Game.Core.Components
{
    public interface IMovable
    {
        public void Move(Vector3 direction);
    }
}