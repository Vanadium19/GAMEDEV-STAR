using Game.Core.Components;
using Game.Modules.FSM;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.AI.States
{
    public class AttackState : IState
    {
        private readonly Blackboard _blackboard;
        private readonly IAttacker _attacker;
        private readonly IRotater _rotater;

        public AttackState(IAttacker attacker,
            IRotater rotater,
            Blackboard blackboard)
        {
            _blackboard = blackboard;
            _attacker = attacker;
            _rotater = rotater;
        }

        public void OnEnter()
        {
            Debug.Log("Вошел в состояние атаки");
        }

        public void OnUpdate(float deltaTime)
        {
            if (!_blackboard.TryGetObject((int)BlackboardTag.Target, out Transform target))
                return;

            _rotater.Rotate(target.position);
            _attacker.Attack();
        }

        public void OnExit()
        {
            Debug.Log("Вышел из состояния атаки");
        }
    }
}