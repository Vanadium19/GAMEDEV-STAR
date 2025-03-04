using Game.Core.Components;
using Game.Modules.Entities;
using Game.Scripts.Common;
using UnityEngine;
using Zenject;

namespace Game.Content.Traps
{
    public class SlowZoneInstaller : MonoInstaller
    {
        [SerializeField] private Entity _entity;
        [SerializeField] private float _multiplier;
        [SerializeField] private int _health = 5;

        public override void InstallBindings()
        {
            //Main
            Container.BindInterfacesAndSelfTo<SlowZone>()
                .AsSingle()
                .WithArguments(_multiplier);

            //MonoBehaviors
            Container.BindInterfacesTo<Entity>()
                .FromInstance(_entity)
                .AsSingle();

            //Components
            Container.BindInterfacesAndSelfTo<HealthComponent>()
                .AsSingle()
                .WithArguments(_health, TeamType.Enemy);
        }
    }
}