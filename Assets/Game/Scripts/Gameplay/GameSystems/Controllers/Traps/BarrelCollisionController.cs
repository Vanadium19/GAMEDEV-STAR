using System;
using Game.Content.Projectiles;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.GameSystems.Traps
{
    public class BarrelCollisionController : MonoBehaviour
    {
        private IAttacker _attacker;

        [Inject]
        private void Construct(IAttacker attacker)
        {
            _attacker = attacker;
        }

        // private void OnCollisionEnter(Collision other)
        // {
        //     if (other.collider.TryGetComponent(out Bullet bullet))
        //         _attacker.Attack();
        // }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Bullet bullet))
                _attacker.Attack();
        }
    }
}