using Game.Core.Components;
using Game.Modules.FSM;
using UnityEngine;

namespace Game.AI.States
{
    public class AttackState : IState
    {
        private readonly IAttacker _attacker;

        public AttackState(IAttacker attacker)
        {
            _attacker = attacker;
        }

        public void OnEnter()
        {
            Debug.Log("Вошел в состояние атаки");
        }

        public void OnUpdate(float deltaTime)
        {
            _attacker.Attack();
        }

        public void OnExit()
        {
            Debug.Log("Вышел из состояния атаки");
        }
    }
}