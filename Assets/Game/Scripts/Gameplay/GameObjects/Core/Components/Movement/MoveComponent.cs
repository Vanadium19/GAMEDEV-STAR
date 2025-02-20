using R3;
using UnityEngine;

namespace Game.Core.Components
{
    public class MoveComponent : EntityComponent, IMovable
    {
        private const float Lapping = 0.5f;

        private readonly Rigidbody _rigidbody;
        private readonly ReactiveProperty<float> _speed;

        private ReactiveProperty<bool> _isMoving = new();

        public MoveComponent(Rigidbody rigidbody, ReactiveProperty<float> speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public ReadOnlyReactiveProperty<bool> IsMoving => _isMoving;

        public void Move(Vector3 direction)
        {
            if (!CheckConditions() || _rigidbody.isKinematic)
            {
                _isMoving.Value = false;
                return;
            }

            Vector3 velocity = direction * _speed.Value + Vector3.up * _rigidbody.velocity.y;

            _isMoving.Value = Mathf.Abs(velocity.x) > Lapping || Mathf.Abs(velocity.z) > Lapping;
            _rigidbody.velocity = velocity;
        }

        public void Freeze(bool value)
        {
            if (value)
            {
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.angularVelocity = Vector3.zero;
            }

            _rigidbody.isKinematic = value;
        }
    }
}