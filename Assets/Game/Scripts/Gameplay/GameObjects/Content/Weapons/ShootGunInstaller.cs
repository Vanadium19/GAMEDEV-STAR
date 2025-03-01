using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.Content.Weapons
{
    public class ShootGunInstaller : MonoInstaller
    {
        [SerializeField] private WeaponParams _params;
        [SerializeField] private int _maxAmmoCount;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ShootGun>()
                .AsSingle()
                .WithArguments(_params, _maxAmmoCount);
        }
    }
}