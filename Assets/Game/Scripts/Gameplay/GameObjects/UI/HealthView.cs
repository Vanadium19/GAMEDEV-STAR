using UnityEngine;

namespace Game.UI
{
    public class HealthView : MonoBehaviour
    {
        public void SetHealth(int health, int maxHealth)
        {
            Debug.Log($"Health changed to {health} / {maxHealth}");
        }
    }
}