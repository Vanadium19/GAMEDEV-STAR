using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class CollisionTracker : IInitializable, IDisposable
    {
        private readonly UnityEventReceiver _unityEvents;
        private readonly string[] _tags;

        public event Action<Collider2D> Entered;

        public CollisionTracker(UnityEventReceiver unityEvents, string[] tags)
        {
            _unityEvents = unityEvents;
            _tags = tags;
        }

        public void Initialize()
        {
            _unityEvents.OnCollisionEntered += OnEntered;
        }

        public void Dispose()
        {
            _unityEvents.OnCollisionEntered -= OnEntered;
        }

        private void OnEntered(Collision2D target)
        {
            if (_tags.Contains(target.collider.tag))
                Entered?.Invoke(target.collider);
        }
    }
}