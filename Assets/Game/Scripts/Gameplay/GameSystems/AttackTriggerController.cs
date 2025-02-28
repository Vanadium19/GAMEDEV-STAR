using Game.Core.Components;
using Game.Core;
using UnityEngine;
using Zenject;

namespace Game.GameSystems
{
    public class AttackTriggerController : MonoBehaviour
    {
        private IAttacker _attacker;

        [Inject]
        private void Construct(IAttacker attacker)
        {
            _attacker = attacker;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity))
                _attacker.Attack();
        }
    }
}