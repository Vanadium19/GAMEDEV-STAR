using System;
using TMPro;
using UnityEngine;

namespace Game.Menu.UI
{
    public class FPSCounter : MonoBehaviour
    {
        private const float ChangeDelay = 1f;

        [SerializeField] private TMP_Text _counter;

        private float _currentTime;

        private void Update()
        {
            if (_currentTime > 0)
            {
                _currentTime -= Time.deltaTime;
                return;
            }

            _counter.text = $"FPS: {(int)(1f / Time.unscaledDeltaTime)}";
            _currentTime = ChangeDelay;
        }
    }
}