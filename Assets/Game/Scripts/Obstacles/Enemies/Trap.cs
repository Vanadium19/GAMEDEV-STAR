using System;
using Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Obstacles.Enemies
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