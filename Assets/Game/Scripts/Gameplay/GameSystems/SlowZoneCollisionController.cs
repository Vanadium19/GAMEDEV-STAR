using System;
using Game.Content.Traps;
using Game.Core;
using UnityEngine;
using Zenject;

namespace Game.GameSystems
{
    public class SlowZoneCollisionController : MonoBehaviour
    {
        private SlowZone _slowZone;

        [Inject]
        public void Construct(SlowZone slowZone)
        {
            _slowZone = slowZone;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity))
                _slowZone.Enter(entity);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity))
                _slowZone.Exit(entity);
        }
    }
}