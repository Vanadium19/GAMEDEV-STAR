using Game.Core.Components;
using Game.Menu.UI;
using Game.View;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class LevelControllerInstaller : MonoInstaller
    {
        private const string Tag = "Player";

        [SerializeField] private Canvas _levelMenuPrefab;
        [SerializeField] private EndLevelView _endLevelTrigger;

        public override void InstallBindings()
        {
            Container.Bind<EndLevelView>()
                .FromInstance(_endLevelTrigger)
                .AsSingle();

            Container.BindInterfacesTo<LevelController>()
                .AsCached()
                .NonLazy();
            
            //UI
            Container.BindFactory<Canvas, LevelMenuFactory>()
                .FromComponentInNewPrefab(_levelMenuPrefab)
                .AsSingle();
        }
    }
}