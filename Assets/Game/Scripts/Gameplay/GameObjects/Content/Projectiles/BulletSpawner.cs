using System;
using Game.Modules.Entities;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Content.Projectiles
{
    public class BulletSpawner
    {
        private readonly EntityWorld _entityWorld;

        public BulletSpawner(EntityWorld entityWorld)
        {
            _entityWorld = entityWorld;
        }

        public void Spawn(string id, int damage, Vector3 velocity, Transform point, TeamType team)
        {
            IEntity entity = _entityWorld.Spawn(id, point.position, point.rotation);

            if (!entity.TryGet(out IBullet bullet))
                throw new ArgumentException($"Invalid bullet id: {id}");

            bullet.Initialize(damage, team, velocity);
        }
    }
}