using Game.Scripts.Common;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Content.Weapons
{
    public class ShootGunInstaller : MonoInstaller
    {
        [SerializeField] private WeaponParams _params;
        [SerializeField] private int _maxAmmoCount;
        [SerializeField] private List<Transform> _shootPoints;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ShootGun>()
                .AsSingle()
                .WithArguments(_params, _shootPoints);
        }
    }
}