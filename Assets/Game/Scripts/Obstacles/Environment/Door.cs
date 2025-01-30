using System;
using UnityEngine;
using Zenject;

namespace Game.Obstacles.Environment
{
    public class Door : IInitializable, IDoor
    {
        private readonly Key[] _keys;
        private readonly int _keyCount;

        private int _currentKeyCount;

        public event Action Opened;
        public event Action Closed;

        public Door(Key[] keys)
        {
            _keyCount = keys.Length;
            _keys = keys;
        }

        public void Initialize()
        {
            foreach (var key in _keys)
                key.Collected += AddKey;
        }

        private void AddKey(Key key)
        {
            _currentKeyCount++;

            if (_currentKeyCount >= _keyCount)
                OpenDoor();

            key.Collected -= AddKey;
            key.Lost += RemoveKey;
        }

        private void RemoveKey(Key key)
        {
            _currentKeyCount--;

            if (_currentKeyCount <= 0)
                Closed?.Invoke();
            
            key.Collected += AddKey;
            key.Lost += RemoveKey;
        }

        private void OpenDoor()
        {
            Opened?.Invoke();
            Debug.Log("Дверь открыта!");
        }
    }
}