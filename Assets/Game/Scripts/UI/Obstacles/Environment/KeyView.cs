using System.Collections.Generic;
using UnityEngine;

namespace Game.UI.Obstacles
{
    public class KeyView : MonoBehaviour
    {
        [SerializeField] private GameObject _keyPrefab;

        private Transform _transform;
        private List<GameObject> _keys = new();

        private void Awake()
        {
            _transform = transform;
        }

        public void AddKey()
        {
            _keys.Add(Instantiate(_keyPrefab, _transform));
        }

        public void RemoveKey()
        {
            if (_keys.Count == 0)
                return;

            GameObject key = _keys[0];
            _keys.Remove(key);
            Destroy(key);
        }
    }
}