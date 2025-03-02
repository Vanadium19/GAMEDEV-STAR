using Game.Modules.FSM;
using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.AI.Installers
{
    public abstract class StateMachinePrototype : MonoBehaviour
    {
        public abstract IStateMachine<StateName> CreateStateMachine(InjectContext context);
    }
}