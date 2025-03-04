using UnityEngine;
using Zenject;

namespace Game.Content.Weapons
{
    public class RifleInstaller : MonoInstaller
    {
        [SerializeField] private WeaponParams _params;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Rifle>()
                .AsSingle()
                .WithArguments(_params);
        }
    }
}