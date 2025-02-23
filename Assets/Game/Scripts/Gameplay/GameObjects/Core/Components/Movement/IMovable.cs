using UnityEngine;
using R3;

namespace Game.Core.Components
{
    public interface IMovable
    { 
        public void Move(Vector3 direction);

        public void SetSpeedMultipler(float value);
        public void NormalizeSpeedMultipler();
    }
}