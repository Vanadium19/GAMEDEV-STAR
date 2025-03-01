using System;
using Game.Core;
using Game.Core.Components;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Content.Projectiles
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private TeamType _team;
        private int _damage;

        public event Action<Bullet> Destroyed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out IEntity entity)
                && entity.TryGet(out IDamagable target)
                && _team != target.Team)
            {
                target.TakeDamage(_damage);
            }
            if(!other.collider.TryGetComponent(out Bullet bullet))
                Destroyed?.Invoke(this);
        }

        public void Initialize(int damage, TeamType team, Vector3 velocity)
        {
            _team = team;
            _damage = damage;
            _rigidbody.velocity = velocity;
        }
    }
}