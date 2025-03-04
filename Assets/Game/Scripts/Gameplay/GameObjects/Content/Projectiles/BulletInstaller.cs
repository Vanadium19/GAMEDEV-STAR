using Game.Modules.Entities;
using UnityEngine;
using Zenject;

namespace Game.Content.Projectiles
{
    public class BulletInstaller : MonoInstaller
    {
        [SerializeField] private Entity _entity;
        [SerializeField] private Rigidbody _rigidbody;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Bullet>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<Entity>()
                .FromInstance(_entity)
                .AsSingle();

            Container.Bind<Rigidbody>()
                .FromInstance(_rigidbody)
                .AsSingle();
        }
    }
}