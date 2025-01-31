using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    [CreateAssetMenu(
        fileName = "CharacterControllersInstaller",
        menuName = "Zenject/New CharacterControllersInstaller"
    )]
    public class CharacterControllersInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoveController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<JumpController>()
                .AsSingle()
                .NonLazy();
        }
    }
}