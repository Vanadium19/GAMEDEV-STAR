using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.GameSystems.Player
{
    public class PlayerControllersInstaller : MonoInstaller
    {
        [SerializeField] private PlayerCollisionController _collisionController;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerMoveController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<PlayerRotateController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<PlayerAttackController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<PlayerInventoryController>()
                .AsSingle()
                .NonLazy();

            Container.Bind<PlayerCollisionController>()
                .FromInstance(_collisionController)
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerReloadController>()
                .AsSingle()
                .NonLazy();
        }
    }
}