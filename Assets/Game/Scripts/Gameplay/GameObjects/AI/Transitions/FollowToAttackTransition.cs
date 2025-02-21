using Game.Modules.FSM;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.AI.Transitions
{
    public class FollowToAttackTransition : AbstractStateTransition<StateName>
    {
        private readonly Blackboard _blackboard;
        private readonly Transform _transform;
        private readonly float _squaredStoppingDistance;

        public FollowToAttackTransition(Blackboard blackboard,
            Transform transform,
            float stoppingDistance)
            : base(StateName.Follow, StateName.Attack)
        {
            _blackboard = blackboard;
            _transform = transform;
            _squaredStoppingDistance = stoppingDistance * stoppingDistance;
        }

        public override bool CanPerform()
        {
            return _blackboard.TryGetObject((int)BlackboardTag.Target, out Transform target)
                   && (target.position - _transform.position).sqrMagnitude <= _squaredStoppingDistance;
        }
    }
}