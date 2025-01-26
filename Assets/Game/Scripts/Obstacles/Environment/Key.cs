using System;
using Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Obstacles.Environment
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private UnityEventReceiver _unityEvents;

        public event Action<Key> Collected;

        private void OnEnable()
        {
            _unityEvents.OnTriggerEntered += OnTriggerEntered;
        }

        private void OnDisable()
        {
            _unityEvents.OnTriggerEntered += OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider2D target)
        {
            if (target.gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
                Collected?.Invoke(this);
            }
        }
    }
}