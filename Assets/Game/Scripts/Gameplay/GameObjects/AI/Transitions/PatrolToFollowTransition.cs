using Game.AI;
using Game.Modules.FSM;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Gameplay.AI
{
    public class PatrolToFollowTransition : AbstractStateTransition<StateName>
    {
        private readonly Blackboard _blackboard;
        private readonly Transform _transform;
        private readonly float _sqrVisionDinstance;
        
        public PatrolToFollowTransition(Blackboard blackboard,Transform transform,float visionDistance) : base(StateName.Patrol,StateName.Follow)
        {
            _blackboard = blackboard;
            _transform = transform;
            _sqrVisionDinstance = visionDistance * visionDistance;
        }

        public override bool CanPerform()
        {
            return _blackboard.TryGetObject((int)BlackboardTag.Target, out Transform target)
                && (target.position - _transform.position).sqrMagnitude <= _sqrVisionDinstance;
        }
    }
}
