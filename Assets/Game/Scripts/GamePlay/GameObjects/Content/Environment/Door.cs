using System;
using Game.Core;
using UnityEngine;
using Zenject;

namespace Game.Content.Environment
{
    public class Door : IInitializable, IDisposable, IDoor
    {
        private readonly ILevelProgressTracker _levelTracker;
        private readonly Key[] _keys;
        private readonly int _keyCount;

        private int _currentKeyCount;

        public event Action<int> KeyCountChanged;
        public event Action Opened;
        public event Action Closed;

        public Door(Key[] keys, ILevelProgressTracker levelTracker)
        {
            _levelTracker = levelTracker;
            _keyCount = keys.Length;
            _keys = keys;
        }
        
        public int KeyCount => _keyCount;

        public void Initialize()
        {
            foreach (var key in _keys)
                key.Collected += AddKey;

            _levelTracker.LevelRestarted += OnLevelRestarted;
        }

        public void Dispose()
        {
            foreach (var key in _keys)
                key.Collected -= AddKey;

            _levelTracker.LevelRestarted -= OnLevelRestarted;
        }

        private void AddKey(Key key)
        {
            _currentKeyCount++;

            KeyCountChanged?.Invoke(_currentKeyCount);

            if (_currentKeyCount >= _keyCount)
                OpenDoor();
        }

        private void OpenDoor()
        {
            Opened?.Invoke();
            Debug.Log("Дверь открыта!");
        }

        private void OnLevelRestarted()
        {
            _currentKeyCount = 0;
            
            KeyCountChanged?.Invoke(_currentKeyCount);
            Closed?.Invoke();
        }
    }
}