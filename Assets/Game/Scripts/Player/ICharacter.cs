using Game.Components;
using UnityEngine;

namespace Game.Player
{
    public interface ICharacter : IMovable
    {
        public void Jump();
    }
}