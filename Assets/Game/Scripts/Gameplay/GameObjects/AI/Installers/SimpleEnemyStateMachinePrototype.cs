using System.Collections.Generic;
using Game.AI.States;
using Game.AI.Transitions;
using Game.Modules.FSM;
using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.AI.Installers
{
    public class SimpleEnemyStateMachinePrototype : StateMachinePrototype
    {
        [SerializeField] private float _attackDistance;

        public override IStateMachine<StateName> CreateStateMachine(InjectContext context)
        {
            DiContainer container = context.Container;
            Blackboard blackboard = container.Resolve<Blackboard>();

            return new AutoStateMachine<StateName>(StateName.Idle,
                new List<(StateName, IState)>
                {
                    (StateName.Idle, new BaseState()),
                    (StateName.Follow, container.Instantiate<TargetFollowState>(new object[] { _attackDistance })),
                    (StateName.Attack, container.Instantiate<AttackState>()),
                },
                new List<IStateTransition<StateName>>
                {
                    new StateTransition<StateName>(StateName.Idle, StateName.Follow, () => blackboard.HasObject((int)BlackboardTag.Target)),
                    container.Instantiate<FollowToAttackTransition>(new object[] { _attackDistance }),
                    container.Instantiate<AttackToFollowTransition>(new object[] { _attackDistance }),
                });
        }
    }
}