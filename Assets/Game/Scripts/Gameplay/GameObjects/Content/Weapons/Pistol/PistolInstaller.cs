using UnityEngine;
using Zenject;

namespace Game.Content.Weapons
{
    public class PistolInstaller : MonoInstaller
    {
        [SerializeField] private WeaponParams _params;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Pistol>()
                .AsSingle()
                .WithArguments(_params);
        }
    }
}