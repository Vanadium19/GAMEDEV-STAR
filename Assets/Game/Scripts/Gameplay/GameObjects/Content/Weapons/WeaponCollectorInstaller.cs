using UnityEngine;
using Zenject;

namespace Game.Content.Weapons
{
    [CreateAssetMenu(
        fileName = "WeaponCollectorInstaller",
        menuName = "Zenject/New Weapon Collector Installer"
    )]
    public class WeaponCollectorInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<WeaponCollector>()
                .AsSingle()
                .NonLazy();
        }
    }
}