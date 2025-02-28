using Game.Core;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.GameSystems
{
    public class AttackCollisionController : MonoBehaviour
    {
        private IAttacker _attacker;

        [Inject]
        private void Construct(IAttacker attacker)
        {
            _attacker = attacker;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out IEntity entity))
                _attacker.Attack();
        }
    }
}