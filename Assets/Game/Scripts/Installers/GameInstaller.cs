using Game.App.Repository;
using Game.App.SaveLoad;
using Game.Menu;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    [CreateAssetMenu(
        fileName = "GameInstaller",
        menuName = "Zenject/New GameInstaller"
    )]
    public class GameInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            //Serializers
            Container.BindInterfacesTo<SettingsSerializer>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<LevelLoaderSerializer>()
                .AsSingle()
                .NonLazy();

            //Saving
            Container.BindInterfacesTo<GameSaveLoader>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<GameRepository>()
                .AsSingle()
                .NonLazy();

            //Managment
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