using System;
using Game.Core;
using Game.Core.Components;
using UnityEngine;

namespace Game.Content.Projectiles
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private int _damage;

        public event Action<Bullet> Destroyed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out IEntity entity) && entity.TryGet(out IDamagable target))
                target.TakeDamage(_damage);

            Destroyed?.Invoke(this);
        }

        public void Initialize(int damage, Vector3 velocity)
        {
            _damage = damage;
            _rigidbody.velocity = velocity;
        }
    }
}