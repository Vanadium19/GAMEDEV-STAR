using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.UI.Obstacles
{
    public class KeysView : MonoBehaviour
    {
        private readonly List<KeyView> _keys = new();
        
        private KeyViewPool _pool;

        [Inject]
        public void Construct(KeyViewPool pool)
        {
            _pool = pool;
        }

        public void AddKey()
        {
            // Debug.Log("Adding Key");
            
            KeyView key = _pool.Spawn();
            _keys.Add(key);
        }

        public void RemoveKey()
        {
            // Debug.Log("Removing Key");
            
            if (_keys.Count == 0)
                return;

            KeyView key = _keys[0];
            
            _keys.Remove(key);
            _pool.Despawn(key);
        }
    }
}