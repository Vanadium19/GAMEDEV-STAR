using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.GameSystems
{
    public class PlayerMoveController : IFixedTickable
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        private readonly IMovable _player;

        public PlayerMoveController(IMovable player)
        {
            _player = player;
        }

        public void FixedTick()
        {
            Vector3 direction = Vector3.right * Input.GetAxisRaw(HorizontalAxis)
                                + Vector3.forward * Input.GetAxisRaw(VerticalAxis);

            _player.Move(direction);
        }
    }
}