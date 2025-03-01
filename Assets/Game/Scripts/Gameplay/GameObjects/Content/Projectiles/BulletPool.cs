using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.Content.Projectiles
{
    public class BulletPool : MonoMemoryPool<int, Vector3, Transform, TeamType, Bullet>
    {
        protected override void Reinitialize(int damage,Vector3 velocity, Transform point, TeamType team, Bullet item)
        {
            item.Initialize(damage, team, velocity);
            item.transform.SetPositionAndRotation(point.position, point.rotation);
        }
    }
}