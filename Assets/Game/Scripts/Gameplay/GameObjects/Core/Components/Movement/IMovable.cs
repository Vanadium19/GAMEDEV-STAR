using UnityEngine;
using R3;

namespace Game.Core.Components
{
    public interface IMovable
    { 
        public void Move(Vector3 direction);

        public void ChangeSpeed(float multiplier);
    }
}