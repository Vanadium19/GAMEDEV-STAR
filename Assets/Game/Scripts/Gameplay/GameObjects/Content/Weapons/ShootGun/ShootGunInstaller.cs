using System.Collections.Generic;
using Game.Modules.Entities;
using UnityEngine;
using Zenject;

namespace Game.Content.Weapons
{
    public class ShootGunInstaller : MonoInstaller
    {
        [SerializeField] private Entity _entity;
        [SerializeField] private WeaponParams _params;
        [SerializeField] private List<Transform> _shootPoints;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ShootGun>()
                .AsSingle()
                .WithArguments(_entity, _params, _shootPoints);
        }
    }
}