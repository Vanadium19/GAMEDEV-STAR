using Game.Content.Weapons;
using UnityEngine;
using Zenject;

namespace Game.GameSystems.Player
{
    public class PlayerReloadController : ITickable
    {
        private IReloadable _weapon;

        public PlayerReloadController(IReloadable weapon)
        {
            _weapon = weapon;
        }

        public void Tick()
        {
            if(Input.GetKey(KeyCode.R) && !_weapon.IsAmmoFull())
                _weapon.Reload();
        }
    }
}
