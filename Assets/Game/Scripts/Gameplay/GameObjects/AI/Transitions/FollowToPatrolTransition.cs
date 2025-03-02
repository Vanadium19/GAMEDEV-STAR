using Game.Modules.FSM;
using Game.Scripts.Common;
using UnityEngine;
using Game.AI;

namespace Game.AI
{
    public class FollowToPatrolTransition : AbstractStateTransition<StateName>
    {
        private readonly Blackboard _blackboard;
        private readonly Transform _transform;
        private readonly float _sqrPatrolDinstance;

        public FollowToPatrolTransition(Blackboard blackboard, Transform transform, float patrolDistance) : base(StateName.Follow,StateName.Patrol)
        {
            _blackboard = blackboard;
            _transform = transform;
            _sqrPatrolDinstance = patrolDistance * patrolDistance;
        }

        public override bool CanPerform()
        {
            return _blackboard.TryGetObject((int)BlackboardTag.Target, out Transform target)
                && (target.position - _transform.position).sqrMagnitude > _sqrPatrolDinstance;
        }
    }
}
