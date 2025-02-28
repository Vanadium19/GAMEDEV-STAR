using Game.Content.Traps;
using Game.Core;
using UnityEngine;
using Zenject;

namespace Game.GameSystems.Traps
{
    public class InteractableAreaCollisionController : MonoBehaviour
    {
        private IInteractableArea _interactableArea;

        [Inject]
        public void Construct(IInteractableArea interactableArea)
        {
            _interactableArea = interactableArea;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity))
                _interactableArea.Enter(entity);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity))
                _interactableArea.Exit(entity);
        }
    }
}