using R3;
using UnityEngine;

namespace Game.Core.Components
{
    public class RotationComponent : EntityComponent, IRotater
    {
        private readonly Transform _transform;
        private readonly ReactiveProperty<float> _speed;

        private float _horizontalAngle;

        public RotationComponent(Transform transform, ReactiveProperty<float> speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Rotate(Vector3 target)
        {
            Vector3 direction = Vector3.ProjectOnPlane(target - _transform.position, Vector3.up).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            _transform.rotation = Quaternion.Slerp(_transform.rotation, rotation, _speed.Value * Time.deltaTime);
        }
    }
}