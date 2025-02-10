using UniRx;
using UnityEngine;

namespace Game.Core.Components
{
    public class Mover
    {
        private const float Lapping = 0.5f;

        private readonly Rigidbody2D _rigidbody;
        private readonly MoveParams _params;

        private bool _isFalling;
        private bool _isMoving;

        public Mover(Rigidbody2D rigidbody,
            MoveParams moveParams)
        {
            _rigidbody = rigidbody;
            _params = moveParams;
        }

        public bool IsFalling => _isFalling;
        public bool IsMoving => _isMoving;

        public void Move(Vector2 direction)
        {
            var velocity = direction * _params.Speed.Value + Vector2.up * _rigidbody.velocity.y;

            SetAnimatorParams(velocity);

            velocity.y -= _params.GravityScale.Value;

            if (velocity.y < 0)
                velocity.y -= _params.FallFactor.Value;

            _rigidbody.velocity = velocity;
        }

        public void FreezePosition(bool value)
        {
            _rigidbody.gravityScale = value ? 0 : 1;
            _rigidbody.isKinematic = value;
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.angularVelocity = 0f;
        }

        private void SetAnimatorParams(Vector2 velocity)
        {
            _isMoving = Mathf.Abs(velocity.x) > Lapping;
            _isFalling = velocity.y < -Lapping;
        }
    }
}