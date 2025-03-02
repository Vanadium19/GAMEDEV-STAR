using Game.Core.Components;
using Game.Modules.FSM;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game.AI.States
{
    public class PatrolState : IState
    {
        private readonly IMovable _movable;
        private readonly IRotater _rotater;
        private readonly Transform _transform;
        private readonly float _sqrMinDistanceToPoint;
        private readonly float _delayBetweenPatrolPoint;
        private readonly float _enteredDelay;
        private readonly List<Transform> _patrolPoints;

        private float _remainsDelayEnteredTime;
        private float _remainsDelayBetweenPatrolPoint;
        
        private int _currentPointIndex = 0;

        public PatrolState(IMovable movable, IRotater rotater, Transform transform,
             List<Transform> patrolPoints, float minDistanceToPoint, float delayBetweenPatrolPoint, float enteredDelay = 0.5f)
        {
            _movable = movable;
            _rotater = rotater;
            _transform = transform;
            _sqrMinDistanceToPoint = minDistanceToPoint * minDistanceToPoint;
            _delayBetweenPatrolPoint = delayBetweenPatrolPoint;
            _enteredDelay = enteredDelay;
            _patrolPoints = patrolPoints;
        }

        public void OnEnter()
        {
            _remainsDelayEnteredTime = _enteredDelay;
            _remainsDelayBetweenPatrolPoint = _delayBetweenPatrolPoint;
            Debug.Log("PatrolState: Enter");
        }

        public void OnExit()
        {
            _movable.Move(Vector3.zero);
            Debug.Log("PatrolState: Exit");
        }

        public void OnUpdate(float deltaTime)
        {
            if (_remainsDelayEnteredTime > 0 || _remainsDelayBetweenPatrolPoint > 0)
                return;
            
            Transform point = _patrolPoints[_currentPointIndex];

            Vector3 distanceVector = point.position - _transform.position;
            Vector3 direction = Vector3.ProjectOnPlane(distanceVector,Vector3.up).normalized;

            _movable.Move(direction);
            _rotater.Rotate(point.position);

            if (point.position.sqrMagnitude <= _sqrMinDistanceToPoint)
            {
                _currentPointIndex++;
                _remainsDelayBetweenPatrolPoint = _delayBetweenPatrolPoint;
            }
            
            _remainsDelayEnteredTime -= deltaTime;
            _remainsDelayBetweenPatrolPoint -= deltaTime;
        }
    }
}
