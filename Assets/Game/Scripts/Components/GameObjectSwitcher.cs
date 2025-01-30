using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Components
{
    public class GameObjectSwitcher
    {
        private readonly GameObject _object;
        private readonly float _delay;

        public GameObjectSwitcher(GameObject gameObject, float delay)
        {
            _object = gameObject;
            _delay = delay;
        }

        public void Enable(bool value)
        {
            EnableWithDelay(value).Forget();
        }
        
        private async UniTaskVoid EnableWithDelay(bool value)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_delay));
            
            _object.SetActive(value);
        }
    }
}