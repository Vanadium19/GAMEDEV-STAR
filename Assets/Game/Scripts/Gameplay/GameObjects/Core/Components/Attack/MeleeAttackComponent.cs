using System;
using Game.Modules.Entities;
using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class MeleeAttackComponent : AbstractAttackComponent, ITickable
    {
        private readonly float _delay;

        private float _currentTime;

        public MeleeAttackComponent(float delay)
        {
            _delay = delay;
        }

        public void Tick()
        {
            if (_currentTime > 0)
                _currentTime -= Time.deltaTime;
        }

        public override void Attack()
        {
            if (!CheckConditions()||_currentTime > 0)
                return;

            Debug.Log("Рукопашная атака!!!");
            InvokeAttacked();
            _currentTime = _delay;
        }
    }
}