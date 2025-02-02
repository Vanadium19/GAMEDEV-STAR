using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class TriggerTracker : IInitializable, IDisposable
    {
        private readonly UnityEventReceiver _unityEvents;
        private readonly string[] _tags;

        public event Action<Collider2D> Entered;

        public TriggerTracker(UnityEventReceiver unityEvents, string[] tags)
        {
            _unityEvents = unityEvents;
            _tags = tags;
        }

        public void Initialize()
        {
            _unityEvents.OnTriggerEntered += OnEntered;
        }

        public void Dispose()
        {
            _unityEvents.OnTriggerEntered -= OnEntered;
        }

        private void OnEntered(Collider2D target)
        {
            if (_tags.Contains(target.tag))
                Entered?.Invoke(target);
        }
    }
}