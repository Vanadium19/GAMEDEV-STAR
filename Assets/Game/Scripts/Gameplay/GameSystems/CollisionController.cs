using Game.Content.Projectiles;
using Game.Core.Components;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.GameSystems
{
    public class CollisionController : MonoBehaviour
    {
        private IAttacker _attacker;

        [Inject]
        private void Construct(IAttacker attacker)
        {
            _attacker = attacker;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.TryGetComponent(out Bullet bullet))
            {
                _attacker.Attack();
            }

        }
    }
}
