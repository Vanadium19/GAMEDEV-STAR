using Game.Content.Enemies;
using Game.Content.Player;
using Game.Content.Projectiles;
using Game.GameSystems.Controllers;
using Game.Menu.UI;
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

        [SerializeField] private Transform _container;
        [SerializeField] private EntityCatalog _catalog;

        [SerializeField] private Transform _levelMenuPrefab;
        [SerializeField] private Transform _canvas;

        public override void InstallBindings()
        {
            //Others
            Container.Bind<CharacterProvider>()
                .AsSingle()
                .WithArguments(_player);

            Container.BindInterfacesAndSelfTo<EntityWorld>()
                .AsSingle()
                .WithArguments(_catalog, Container, _container);

            Container.BindInterfacesAndSelfTo<EnemiesCounter>()
                .AsSingle()
                .NonLazy();

            //Controllers
            Container.BindInterfacesTo<MenuController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<LevelProgressController>()
                .AsSingle()
                .NonLazy();

            Container.BindFactory<Transform, LevelMenuFactory>()
                .FromComponentInNewPrefab(_levelMenuPrefab)
                .UnderTransform(_canvas)
                .AsSingle();

            //Bullets
            Container.Bind<BulletSpawner>()
                .AsSingle()
                .NonLazy();

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