using Game.Core.Components;
using UnityEngine;

namespace Game.Content.Environment
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