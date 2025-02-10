using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class MoveController : IFixedTickable
    {
        private const string HorizontalAxis = "Horizontal";

        private readonly IMovable _character;

        public MoveController(IMovable character)
        {
            _character = character;
        }

        public void FixedTick()
        {
            Vector2 direction = Input.GetAxisRaw(HorizontalAxis) * Vector2.right;

            _character.Move(direction);
        }
    }
}