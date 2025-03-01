using System.Collections.Generic;
using Game.Core;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Traps
{
    public class DamageArea : ITickable, IInteractableArea
    {
        private readonly int _damage;
        private readonly float _delay;

        private readonly List<IDamagable> _targets = new();

        private float _currentTime;

        public DamageArea(int damage, float delay)
        {
            _damage = damage;
            _delay = delay;
        }

        public void Tick()
        {
            if (_targets.Count == 0)
                return;

            if (_currentTime > 0)
                _currentTime -= Time.deltaTime;

            Attack();
        }

        public void Enter(IEntity entity)
        {
            if (entity.TryGet(out IDamagable target))
                _targets.Add(target);
        }

        public void Exit(IEntity entity)
        {
            if (entity.TryGet(out IDamagable target))
                _targets.Remove(target);
        }

        private void Attack()
        {
            if (_currentTime > 0)
                return;

            _targets.ForEach(target => target.TakeDamage(_damage));
            _currentTime = _delay;
        }
    }
}