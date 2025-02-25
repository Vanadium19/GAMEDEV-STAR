using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;

        public void SetHealth(int health, int maxHealth)
        {
            Debug.Log($"Health changed to {health} / {maxHealth}");

            _healthBar.fillAmount = Mathf.Clamp01(Convert.ToSingle(health) / maxHealth);
        }
    }
}