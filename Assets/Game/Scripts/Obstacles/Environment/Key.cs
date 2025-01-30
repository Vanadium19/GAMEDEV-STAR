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
        public event Action<Key> Lost;

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

                if (target.TryGetComponent(out IDamagable player))
                    player.Died += OnPlayerDied;
            }
        }

        private void OnPlayerDied(IDamagable player)
        {
            // Debug.Log("Lost key");
            
            Lost?.Invoke(this);
            gameObject.SetActive(true);
            
            player.Died -= OnPlayerDied;
        }
    }
}