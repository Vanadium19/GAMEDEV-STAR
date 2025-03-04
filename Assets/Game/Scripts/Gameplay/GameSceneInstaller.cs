using Game.Content.Enemies;
using Game.Content.Player;
using Game.Content.Projectiles;
using Game.Modules.Entities;
using Game.View;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private Entity _player;
        [SerializeField] private EnemiesCountView _enemiesCountView;

        [Header("Bullets")] [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _bulletsContainer;

        public override void InstallBindings()
        {
            Container.Bind<CharacterProvider>()
                .AsSingle()
                .WithArguments(_player);

            Container.BindInterfacesAndSelfTo<EntityWorld>()
                .AsSingle()
                .NonLazy();
            
            Container.BindInterfacesAndSelfTo<EnemiesCounter>()
                .AsSingle()
                .NonLazy();

            //Bullets
            BulletsInstaller.Install(Container, _bulletPrefab, _bulletsContainer);

            //Presenters
            Container.BindInterfacesTo<EntityWorldPresenter>()
                .AsSingle()
                .NonLazy();

            //UI
            Container.Bind<EnemiesCountView>()
                .FromInstance(_enemiesCountView)
                .AsSingle();
        }
    }
}