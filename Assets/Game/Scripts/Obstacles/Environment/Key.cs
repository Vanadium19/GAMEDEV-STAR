using System;
using Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Obstacles.Environment
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
                // Debug.Log("Collected key");

                gameObject.SetActive(false);
                Collected?.Invoke(this);
                _tracker.LevelRestarted += OnLevelRestarted;
            }
        }

        private void OnLevelRestarted()
        {
            // Debug.Log("Lost key");

            gameObject.SetActive(true);
            _tracker.LevelRestarted -= OnLevelRestarted;
        }
    }
}