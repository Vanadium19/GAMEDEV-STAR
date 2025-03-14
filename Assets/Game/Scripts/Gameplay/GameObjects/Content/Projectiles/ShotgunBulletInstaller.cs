using Game.Modules.Entities;
using UnityEngine;
using Zenject;

namespace Game.Content.Projectiles
{
    public class ShotgunBulletInstaller : MonoInstaller
    {
        [SerializeField] private Entity _entity;
        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private float _delay = 0.5f;
        [SerializeField] private float _damageMultiplier = 0.5f;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ShotgunBullet>()
                .AsSingle()
                .WithArguments(_damageMultiplier, _delay)
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