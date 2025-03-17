using System;
using Game.Modules.Entities;
using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class MeleeAttackComponent : AbstractAttackComponent, ITickable
    {
        private const int ColliderBufferSize = 5;

        private readonly MeleeAttackParams _params;
        private readonly TeamType _team;

        private float _currentTime;

        public MeleeAttackComponent(MeleeAttackParams attackParams, TeamType team)
        {
            _team = team;
            _params = attackParams;
        }

        public void Tick()
        {
            if (_currentTime > 0)
                _currentTime -= Time.deltaTime;
        }

        public override void Attack()
        {
            if (!CheckConditions() || _currentTime > 0)
                return;

            AttackWithOverlap();
            InvokeAttacked();
            _currentTime = _params.Delay;
        }

        private void AttackWithOverlap()
        {
            System.Buffers.ArrayPool<Collider> arrayPool = System.Buffers.ArrayPool<Collider>.Shared;
            Collider[] colliders = arrayPool.Rent(ColliderBufferSize);

            int size = Physics.OverlapSphereNonAlloc(_params.Point.position, _params.Radius, colliders);

            for (int i = 0; i < size; i++)
            {
                if (colliders[i].TryGetComponent(out IEntity entity) && entity.TryGet(out IDamagable target))
                {
                    if (target.Team != _team)
                    {
                        target.TakeDamage(_params.Damage);
                    }
                }
            }

            arrayPool.Return(colliders);
        }
    }
}