using Game.Menu.Core;
using UnityEngine;
using Zenject;

namespace Game.GameSystems.Controllers
{
    public class MenuController : ITickable
    {
        private readonly MenuFacade _menuFacade;

        public MenuController(MenuFacade menuFacade)
        {
            _menuFacade = menuFacade;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                _menuFacade.OpenMenu();

            if (Input.GetKeyDown(KeyCode.Tab))
                _menuFacade.OpenDeathPanel();
        }
    }
}