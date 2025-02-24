using Game.Core.Components;
using Game.Modules.FSM;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.AI.States
{
    public class TargetFollowState : IState
    {
        private readonly IMovable _movable;
        private readonly IRotater _rotater;
        private readonly Transform _transform;
        private readonly Blackboard _blackboard;
        private readonly float _squaredStoppingDistance;
        private readonly float _enteredDelay;

        private float _currentTime;

        public TargetFollowState(IMovable movable,
            IRotater rotater,
            Transform transform,
            Blackboard blackboard,
            float stoppingDistance,
            float enteredDelay = 0.5f)
        {
            _movable = movable;
            _rotater = rotater;
            _transform = transform;
            _blackboard = blackboard;
            _enteredDelay = enteredDelay;
            _squaredStoppingDistance = stoppingDistance * stoppingDistance;
        }

        public void OnEnter()
        {
            _currentTime = _enteredDelay;

            Debug.Log("Вошел в состояние преследования");
        }

        public void OnUpdate(float deltaTime)
        {
            if (_currentTime > 0)
            {
                _currentTime -= deltaTime;
                return;
            }

            if (!_blackboard.TryGetObject((int)BlackboardTag.Target, out Transform target))
            {
                _movable.Move(Vector3.zero);
                return;
            }

            Vector3 distanceVector = target.position - _transform.position;

            if (distanceVector.sqrMagnitude <= _squaredStoppingDistance)
            {
                _movable.Move(Vector3.zero);
                return;
            }

            Vector3 direction = Vector3.ProjectOnPlane(distanceVector, Vector3.up).normalized;
            
            _movable.Move(direction);
            _rotater.Rotate(target.position);
        }

        public void OnExit()
        {
            _movable.Move(Vector3.zero);

            Debug.Log("Вышел из состояния преследования");
        }
    }
}