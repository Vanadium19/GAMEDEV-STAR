using Zenject;
using UnityEngine;
using Game.Content.PickUp;
using Game.Modules.Entities;

namespace Game.Gameplay.Content.PickUp
{
    public class MedicInstaller : MonoInstaller
    {
        [SerializeField] private int _heal;
        [SerializeField] private Entity _entity;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Entity>()
                .FromInstance(_entity)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<Medic>()
                .AsSingle()
                .WithArguments(_heal);
        }
    }
}