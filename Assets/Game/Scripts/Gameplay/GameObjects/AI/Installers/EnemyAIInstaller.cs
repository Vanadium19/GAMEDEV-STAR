using System.Collections.Generic;
using Game.AI.Sensors;
using Game.AI.States;
using Game.Modules.FSM;
using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.AI.Installers
{
    public class EnemyAIInstaller : MonoInstaller
    {
        [SerializeField] private float _stoppingDistance;
        [SerializeField] private TargetEnteredSensor _targetEnteredSensor;

        public override void InstallBindings()
        {
            Container.Bind<TargetEnteredSensor>()
                .FromInstance(_targetEnteredSensor)
                .AsSingle();

            Container.Bind<Blackboard>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<AIAgent>()
                .AsSingle()
                .NonLazy();

            Container.Bind<IStateMachine<StateName>>()
                .FromMethod(CreateStateMachine);
        }

        private IStateMachine<StateName> CreateStateMachine(InjectContext context)
        {
            DiContainer container = context.Container;

            Blackboard blackboard = container.Resolve<Blackboard>();
            Transform enemy = container.Resolve<Transform>();

            return new AutoStateMachine<StateName>(StateName.Idle,
                new List<(StateName, IState)>
                {
                    (StateName.Idle, new BaseState()),
                    (StateName.Follow, Container.Instantiate<TargetFollowState>(new object[] { _stoppingDistance })),
                    (StateName.Attack, Container.Instantiate<AttackState>()),
                },
                new List<IStateTransition<StateName>>
                {
                    new StateTransition<StateName>(StateName.Idle, StateName.Follow, () => blackboard.HasObject((int)BlackboardTag.Target)),
                    new StateTransition<StateName>(StateName.Follow, StateName.Attack, () => blackboard.TryGetObject((int)BlackboardTag.Target, out Transform target) && (enemy.position - target.position).sqrMagnitude <= _stoppingDistance * _stoppingDistance),
                    new StateTransition<StateName>(StateName.Attack, StateName.Follow, () => blackboard.TryGetObject((int)BlackboardTag.Target, out Transform target) && (enemy.position - target.position).sqrMagnitude > _stoppingDistance * _stoppingDistance),
                });
        }
    }
}