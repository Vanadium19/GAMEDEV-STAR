using Game.Content.Player;
using Game.Core;
using Game.Menu.UI;
using Game.View;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class LevelControllerInstaller : MonoInstaller
    {
        [SerializeField] private Canvas _levelMenuPrefab;
        [SerializeField] private EndLevelView _endLevelTrigger;
        [SerializeField] private Entity _player;

        public override void InstallBindings()
        {
            Container.Bind<EndLevelView>()
                .FromInstance(_endLevelTrigger)
                .AsSingle();

            Container.Bind<CharacterProvider>()
                .AsSingle()
                .WithArguments(_player);

            Container.BindInterfacesAndSelfTo<LevelController>()
                .AsCached()
                .NonLazy();
            
            //UI
            Container.BindFactory<Canvas, LevelMenuFactory>()
                .FromComponentInNewPrefab(_levelMenuPrefab)
                .AsSingle();
        }
    }
}