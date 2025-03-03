using System;
using Game.Modules.FSM;
using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.AI
{
    public class AIAgent : IInitializable, ITickable, IDisposable
    {
        private readonly IStateMachine<StateName> _stateMachine;

        public AIAgent(IStateMachine<StateName> stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            _stateMachine.OnEnter();
        }

        public void Tick()
        {
            _stateMachine.OnUpdate(Time.deltaTime);
        }

        public void Dispose()
        {
            _stateMachine.OnExit();
        }
    }
}