using System;
using Game.Core;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Environment
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private UnityEventReceiver _unityEvents;

        private ILevelProgressTracker _tracker;

        public event Action<Key> Collected;

        [Inject]
        public void Construct(ILevelProgressTracker tracker)
        {
            _tracker = tracker;
        }

        private void OnEnable()
        {
            _unityEvents.OnTriggerEntered += OnEntered;
        }

        private void OnDisable()
        {
            _unityEvents.OnTriggerEntered -= OnEntered;
        }

        private void OnEntered(Collider2D target)
        {
            if (target.gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
                Collected?.Invoke(this);
                _tracker.LevelRestarted += OnLevelRestarted;
            }
        }

        private void OnLevelRestarted()
        {
            gameObject.SetActive(true);
            _tracker.LevelRestarted -= OnLevelRestarted;
        }
    }
}