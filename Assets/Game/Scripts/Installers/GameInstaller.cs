using Game.Menu.Core;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    [CreateAssetMenu(fileName = "GameInstaller",
        menuName = "Zenject/New GameInstaller")]
    public class GameInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            BindManagers();
        }

        private void BindManagers()
        {
            Container.BindInterfacesTo<VolumeSettings>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<LevelLoader>()
                .AsSingle()
                .NonLazy();

            Container.Bind<GameSettings>()
                .AsSingle()
                .NonLazy();

            Container.Bind<MenuFacade>()
                .AsSingle()
                .NonLazy();
        }
    }
}