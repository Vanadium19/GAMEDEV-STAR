using UnityEngine;

namespace Game.Core.Components
{
    public class Mover
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;

        public Mover(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void Move(Vector2 direction)
        {
            Vector2 velocity = direction * _speed + Vector2.up * _rigidbody.velocity.y;

            _rigidbody.velocity = velocity;
        }

        public void FreezePosition(bool value)
        {
            _rigidbody.gravityScale = value ? 0 : 1;
            _rigidbody.isKinematic = value;

            if (value)
            {
                _rigidbody.velocity = Vector2.zero;
                _rigidbody.angularVelocity = 0f;
            }
        }
    }
}