using Game.Content.Player;
using Game.Core.Components;
using Game.Core.Inventories;
using UnityEngine;
using Zenject;

namespace Game.GameSystems.Player
{
    public class PlayerInventoryController : ITickable
    {
        private readonly IPickUpList _pickUpList;
        private readonly IInventory _inventory;

        public PlayerInventoryController(IPickUpList pickUpList, IInventory inventory)
        {
            _pickUpList = pickUpList;
            _inventory = inventory;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.E))
                _pickUpList.Collect();

            if (Input.GetKeyDown(KeyCode.Tab))
                _inventory.ChangeWeapon();
        }
    }
}