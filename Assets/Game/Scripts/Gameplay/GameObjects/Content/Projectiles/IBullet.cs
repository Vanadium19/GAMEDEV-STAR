using Game.Modules.Entities;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Content.Projectiles
{
    public interface IBullet
    {
        public void Initialize(int damage, TeamType team, Vector3 velocity);
        public void Attack(IEntity entity);
    }
}