using Game.Modules.Entities;
using UnityEngine;
using Zenject;

namespace Game.Content.Traps
{
    public class DamageAreaInstaller : MonoInstaller
    {
        [SerializeField] private Entity _entity;
        [SerializeField] private float _delay = 0.5f;
        [SerializeField] private int _damage = 3;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Entity>()
                .FromInstance(_entity)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<DamageArea>()
                .AsSingle()
                .WithArguments(_damage, _delay);
        }
    }
}