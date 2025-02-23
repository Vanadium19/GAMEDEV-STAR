using Game.Core.Components;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Gameplay.GameSystems
{
    [RequireComponent(typeof(BoxCollider))]
    public class TriggerController : MonoBehaviour
    {
        [SerializeField] private List<string> _tags;
        private IAttacker _attacker;

        private void Construct(IAttacker attacker)
        {
            _attacker = attacker;
        }

        private void Awake()
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_tags.Contains(other.tag))
            {
                _attacker.Attack();
            }
        }
    }
}
