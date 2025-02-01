using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    [CreateAssetMenu(
        fileName = "LevelControllerInstaller",
        menuName = "Zenject/New LevelControllerInstaller"
    )]
    public class LevelControllerInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LevelRestarter>()
                .AsCached()
                .NonLazy();
        }
    }
}