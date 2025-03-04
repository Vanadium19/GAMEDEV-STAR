using Game.Modules.Entities;
using UnityEngine;
using Zenject;

namespace Game.Content.Weapons
{
    public class PistolInstaller : MonoInstaller
    {
        [SerializeField] private Entity _entity;
        [SerializeField] private WeaponParams _params;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Pistol>()
                .AsSingle()
                .WithArguments(_entity, _params);
        }
    }
}