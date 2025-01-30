using System;
using Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Obstacles.Enemies
{
    public class PlatformTrap : IInitializable, IDisposable
    {
        private readonly CollisionTracker _tracker;
        private readonly GameObjectSwitcher _switcher;

        public PlatformTrap(CollisionTracker tracker, GameObjectSwitcher switcher)
        {
            _tracker = tracker;
            _switcher = switcher;
        }

        public void Initialize()
        {
            _tracker.Entered += OnEntered;
        }

        public void Dispose()
        {
            _tracker.Entered -= OnEntered;
        }

        private void OnEntered(Collider2D target)
        {
            _switcher.Enable(false);
        }
    }
}