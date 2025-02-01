using System;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Enemies
{
    public class Trap : IInitializable, IDisposable
    {
        private readonly TriggerTracker _tracker;
        private readonly Attacker _attacker;

        public Trap(TriggerTracker tracker, Attacker attacker)
        {
            _tracker = tracker;
            _attacker = attacker;
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
            _attacker.Attack(target);
        }
    }
}