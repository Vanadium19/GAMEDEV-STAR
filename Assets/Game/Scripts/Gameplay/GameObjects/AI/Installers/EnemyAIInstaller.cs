using Game.AI.Sensors;
using Game.Modules.FSM;
using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.AI.Installers
{
    public class EnemyAIInstaller : MonoInstaller
    {
        [SerializeField] private TargetEnteredSensor _targetEnteredSensor;
        [SerializeField] private StateMachinePrototype _stateMachine;

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
                .FromMethod(_stateMachine.CreateStateMachine);
        }
    }
}