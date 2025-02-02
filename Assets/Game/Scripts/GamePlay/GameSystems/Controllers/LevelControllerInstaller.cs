using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class LevelControllerInstaller : MonoInstaller
    {
        private const string Tag = "Player";

        [SerializeField] private UnityEventReceiver _endLevelTrigger;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TriggerTracker>()
                .AsSingle()
                .WithArguments(_endLevelTrigger, new[] { Tag });

            Container.BindInterfacesTo<LevelController>()
                .AsCached()
                .NonLazy();
        }
    }
}