using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.Content.Projectiles
{
    public class BulletPool : MonoMemoryPool<int, float, Transform, TeamType, Bullet>
    {
        protected override void Reinitialize(int damage, float speed, Transform point, TeamType team, Bullet item)
        {
            item.Initialize(damage, team, point.forward * speed);
            item.transform.SetPositionAndRotation(point.position, point.rotation);
        }
    }
}