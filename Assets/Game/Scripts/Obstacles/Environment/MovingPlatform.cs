using Game.Components;
using UnityEngine;

namespace Game.Obstacles.Environment
{
    public class MovingPlatform : IMovable
    {
        private readonly Transform _transform;
        private readonly TransformMover _mover;

        public MovingPlatform(Transform transform, TransformMover mover)
        {
            _transform = transform;
            _mover = mover;
        }

        public Vector2 Position => _transform.position;

        public void Move(Vector2 direction)
        {
            _mover.Move(direction);
        }
    }
}