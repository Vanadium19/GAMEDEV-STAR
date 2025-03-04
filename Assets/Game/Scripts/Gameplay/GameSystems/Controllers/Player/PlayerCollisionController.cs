using Game.Core.Components;
using Game.Modules.Entities;
using UnityEngine;
using Zenject;

namespace Game.GameSystems.Player
{
    public class PlayerCollisionController : MonoBehaviour
    {
        private IPickUpList _pickUpList;

        [Inject]
        public void Construct(IPickUpList pickUpList)
        {
            _pickUpList = pickUpList;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity) && entity.TryGet(out ICollectable collectable))
            {
                Debug.Log(other.gameObject.name);
                
                Debug.Log("Add");
                _pickUpList.Add(collectable);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity) && entity.TryGet(out ICollectable collectable))
            {
                Debug.Log("Remove");
                _pickUpList.Remove(collectable);
            }
        }
    }
}