using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.GameSystems.Player
{
    public class PlayerRotateController : IFixedTickable
    {
        private readonly IRotater _player;
        private readonly Camera _camera;
        private readonly float _cursorZ;

        public PlayerRotateController(IRotater player)
        {
            _player = player;
            _camera = Camera.main;
            _cursorZ = _camera.transform.position.y;
        }

        public void FixedTick()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = _cursorZ;

            Vector3 target = _camera.ScreenToWorldPoint(mousePosition);

            _player.Rotate(target);
        }
    }
}