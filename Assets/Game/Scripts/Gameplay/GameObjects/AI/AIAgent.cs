using Game.Modules.FSM;
using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.AI
{
    public class AIAgent : ITickable
    {
        private readonly IStateMachine<StateName> _stateMachine;

        public AIAgent(IStateMachine<StateName> stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Tick()
        {
            _stateMachine.OnUpdate(Time.deltaTime);
        }
    }
}