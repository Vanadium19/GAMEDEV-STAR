using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.UI.Obstacles
{
    public class DoorView : MonoBehaviour
    {
        private readonly List<KeyView> _keys = new();

        private KeyViewPool _pool;

        [Inject]
        public void Construct(KeyViewPool pool)
        {
            _pool = pool;
        }

        public void Open()
        {
            gameObject.SetActive(false);
        }

        public void Close()
        {
            gameObject.SetActive(true);
        }

        public void AddKey()
        {
            // Debug.Log("Adding Key");

            KeyView key = _pool.Spawn();
            _keys.Add(key);
        }

        public void RemoveAllKeys()
        {
            // Debug.Log("Removing Keys");

            foreach (KeyView key in _keys)
                _pool.Despawn(key);

            _keys.Clear();
        }
    }
}