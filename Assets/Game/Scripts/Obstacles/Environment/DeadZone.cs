using Game.Components;
using UnityEngine;

namespace Game.Obstacles.Environment
{
    public class DeadZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamagable target))
                target.TakeDamage(int.MaxValue);
        }
    }
}