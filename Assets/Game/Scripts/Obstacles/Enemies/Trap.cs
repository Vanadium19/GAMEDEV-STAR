using Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Obstacles.Enemies
{
    public class Trap : MonoBehaviour
    {
        private UnityEventReceiver _unityEvents;
        private Attacker _attacker;

        [Inject]
        public void Construct(UnityEventReceiver unityEvents, Attacker attacker)
        {
            _unityEvents = unityEvents;
            _attacker = attacker;
        }

        private void OnEnable()
        {
            _unityEvents.OnTriggerEntered += OnTriggerEntered;
        }

        private void OnDisable()
        {
            _unityEvents.OnTriggerEntered -= OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider2D target)
        {
            _attacker.Attack(target);
        }
    }
}