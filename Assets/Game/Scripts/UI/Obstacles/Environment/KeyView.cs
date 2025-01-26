using System;
using UnityEngine;

namespace Game.UI.Obstacles
{
    public class KeyView : MonoBehaviour
    {
        [SerializeField] private GameObject _keyPrefab;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void AddKey()
        {
            Instantiate(_keyPrefab, _transform);
        }
    }
}