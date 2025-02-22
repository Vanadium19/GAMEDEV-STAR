using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.Components
{
    public class ZoneAttackComponent : EntityComponent, IAttacker
    {
        private readonly Transform _transform;
        private float _attackRadius;
        private int _damage;

        public ZoneAttackComponent(Transform transform, float attackRadius, int damage)
        {
            _transform = transform;
            _attackRadius = attackRadius;
            _damage = damage;
        }

        public void Attack()
        {
            List<IDamagable> damagables = GetAllDamagableEntitiesFromColliders(GetAllCollidersInHitRadius());
            TakeDamageToAllDamagableEntities(damagables);
        }

        private Collider[] GetAllCollidersInHitRadius()
        {
            return Physics.OverlapSphere(_transform.position,_attackRadius);
        }

        private List<IDamagable> GetAllDamagableEntitiesFromColliders(Collider[] colliders) 
        {
            List<IDamagable> damagableEntities = new List<IDamagable>();
            for(int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].TryGetComponent(out IEntity entity) && entity.TryGet(out IDamagable damagable))
                {
                    damagableEntities.Add(damagable);
                }
            }
            return damagableEntities;
        }

        private void TakeDamageToAllDamagableEntities(List<IDamagable> damagables)
        {
            foreach(var damagable in damagables)
            {
                damagable.TakeDamage(_damage);
                Debug.Log($"{damagable} получил урон");
            }
        }

    }
}
