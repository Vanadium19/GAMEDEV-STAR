using Game.Core.Components;
using Game.Modules.Entities;
using UnityEngine;
using Zenject;

namespace Game.GameSystems.Traps
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