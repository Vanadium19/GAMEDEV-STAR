using UnityEngine;

namespace Game.Core.Components
{
    public class Mover
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;

        private Vector2 _velocity;
        
        public Mover(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public Vector2 Velocity => _velocity;

        public void Move(Vector2 direction)
        {
            _velocity = direction * _speed + Vector2.up * _rigidbody.velocity.y;

            _rigidbody.velocity = _velocity;
        }

        public void FreezePosition(bool value)
        {
            _rigidbody.gravityScale = value ? 0 : 1;
            _rigidbody.isKinematic = value;
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.angularVelocity = 0f;
        }
    }
}