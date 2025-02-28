using System.Collections.Generic;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.GameSystems
{
    public class CollisionController : MonoBehaviour
    {
        [SerializeField] private List<string> _tags;
        private IAttacker _attacker;

        [Inject]
        private void Construct(IAttacker attacker)
        {
            _attacker = attacker;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(_tags.Contains(collision.collider.tag))
            {
                _attacker.Attack();
            }

        }
    }
}
