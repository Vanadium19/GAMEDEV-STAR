using System;
using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class MeleeAttackComponent : EntityComponent, IAttacker, ITickable
    {
        private readonly float _delay;

        private float _currentTime;

        public event Action Attacked;

        public MeleeAttackComponent(float delay)
        {
            _delay = delay;
        }

        public void Tick()
        {
            if (_currentTime > 0)
                _currentTime -= Time.deltaTime;
        }

        public void Attack()
        {
            if (_currentTime > 0)
                return;

            Debug.Log("Атака!!!");
            Attacked?.Invoke();
            _currentTime = _delay;
        }
    }
}