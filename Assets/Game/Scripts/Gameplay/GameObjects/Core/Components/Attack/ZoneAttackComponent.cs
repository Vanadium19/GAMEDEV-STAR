using System;
using Game.Modules.Entities;
using UnityEngine;

namespace Game.Core.Components
{
    public class ZoneAttackComponent : AbstractAttackComponent
    {
        private const int _maxCollidersCount = 10;
        
        private readonly Transform _transform;
        private readonly float _attackRadius;
        private readonly int _damage;

        public ZoneAttackComponent(Transform transform, float attackRadius, int damage)
        {
            _transform = transform;
            _attackRadius = attackRadius;
            _damage = damage;
        }

        public override void Attack()
        {
            if (!CheckConditions())
                return;

            Collider[] colliders = new Collider[_maxCollidersCount];
            int collidersCount = Physics.OverlapSphereNonAlloc(_transform.position, _attackRadius, colliders);

            for(int i = 0; i < collidersCount; i++)
            {
                if (colliders[i].TryGetComponent(out IEntity entity) && entity.TryGet(out IDamagable damagable))
                {
                    damagable.TakeDamage(_damage);
                }
            }
            InvokeAttacked();
        }
    }
}