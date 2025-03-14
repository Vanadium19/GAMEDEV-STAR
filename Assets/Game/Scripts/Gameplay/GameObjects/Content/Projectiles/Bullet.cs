using Game.Core.Components;
using Game.Modules.Entities;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Content.Projectiles
{
    public class Bullet : IBullet
    {
        private readonly Rigidbody _rigidbody;

        private TeamType _team;
        private int _damage;

        public Bullet(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Initialize(int damage, TeamType team, Vector3 velocity)
        {
            _team = team;
            _damage = damage;
            _rigidbody.velocity = velocity;

            OnInitialize();
        }

        public void Attack(IEntity entity)
        {
            if (entity.TryGet(out IDamagable target) && _team != target.Team)
                target.TakeDamage(_damage);
        }

        protected void MultiplyDamage(float multiplier)
        {
            _damage = (int)(_damage * multiplier);
        }

        protected virtual void OnInitialize()
        {
        }
    }
}