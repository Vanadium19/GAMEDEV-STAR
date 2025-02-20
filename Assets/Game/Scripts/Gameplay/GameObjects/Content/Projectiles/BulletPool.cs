using UnityEngine;
using Zenject;

namespace Game.Content.Projectiles
{
    public class BulletPool : MonoMemoryPool<int, float, Transform, Bullet>
    {
        protected override void Reinitialize(int damage, float speed, Transform point, Bullet item)
        {
            item.Initialize(damage, point.forward * speed);
            item.transform.SetPositionAndRotation(point.position, point.rotation);
        }
    }
}