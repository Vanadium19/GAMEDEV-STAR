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
            Container.BindInterfacesAndSelfTo<GameSettings>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<LevelLoader>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<MenuFacade>()
                .AsSingle()
                .NonLazy();
        }
    }
}