﻿using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.GameSystems.Player
{
    public class PlayerAttackController : ITickable
    {
        private readonly IAttacker _player;

        public PlayerAttackController(IAttacker player)
        {
            _player = player;
        }

        public void Tick()
        {
            if (Input.GetKey(KeyCode.Mouse0))
                _player.Attack();
        }
    }
}