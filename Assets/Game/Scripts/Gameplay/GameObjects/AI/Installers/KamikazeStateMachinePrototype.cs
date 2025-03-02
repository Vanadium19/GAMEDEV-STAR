using System.Collections.Generic;
using Game.AI.States;
using Game.AI.Transitions;
using Game.Modules.FSM;
using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.AI.Installers
{
    public class KamikazeStateMachinePrototype : StateMachinePrototype
    {
        [SerializeField] private float _attackDistance;
        [SerializeField] private float _minDistanceToPoint;
        [SerializeField] private float _delayTimeBetweenPoint;
        [SerializeField] private List<Transform> _patrolPoints;

        public override IStateMachine<StateName> CreateStateMachine(InjectContext context)
        {
            DiContainer container = context.Container;
            Blackboard blackboard = container.Resolve<Blackboard>();

            return new AutoStateMachine<StateName>(StateName.Patrol,
                new List<(StateName, IState)>
                {
                    (StateName.Patrol, container.Instantiate<PatrolState>(new object[] { _minDistanceToPoint, _delayTimeBetweenPoint, _patrolPoints })),
                    (StateName.Follow, container.Instantiate<TargetFollowState>(new object[] { _attackDistance })),
                    (StateName.Attack, container.Instantiate<AttackState>()),
                },
                new List<IStateTransition<StateName>>
                {
                    new StateTransition<StateName>(StateName.Patrol, StateName.Follow, () => blackboard.HasObject((int)BlackboardTag.Target)),
                    container.Instantiate<FollowToAttackTransition>(new object[] { _attackDistance }),
                    container.Instantiate<AttackToFollowTransition>(new object[] { _attackDistance }),
                });
        }
    }
}