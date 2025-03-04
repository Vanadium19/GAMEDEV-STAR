using System;

namespace Game.Content.Weapons
{
    public interface IReloadable
    {
        public event Action Reloading;

        public bool IsAmmoFull();
        public void Reload();
    }
}
