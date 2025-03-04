using Game.Content.Projectiles;
using Game.Modules.Entities;
using UnityEngine;
using Zenject;

namespace Game.GameSystems.Controllers
{
    public class BulletCollisionController : MonoBehaviour
    {
        private IBullet _bullet;
        private IEntity _entity;

        [Inject]
        public void Construct(IBullet bullet, IEntity entity)
        {
            _bullet = bullet;
            _entity = entity;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out IEntity entity))
                _bullet.Attack(entity);

            _entity.Destroy();
        }
    }
}