using System;
using Game.Content.Player;
using Game.Core;
using UnityEngine;

namespace Game.View
{
    public class EndLevelView : MonoBehaviour
    {
        [SerializeField] private AudioSource _audio;
        [SerializeField] private float _delay = 2f;

        public event Action<float> LevelEnded;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IEntity entity))
            {
                if (entity.TryGet(out Character player))
                {
                    LevelEnded?.Invoke(_delay);
                    _audio.Play();
                }
            }
        }
    }
}