using Game.Content.Environment;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Installers
{
    public class MovingPlatformInstaller : MonoInstaller
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private float _speed = 2;

        public override void InstallBindings()
        {
            Container.Bind<Transform>()
                .FromInstance(_transform)
                .AsCached();

            Container.Bind<TransformMover>()
                .AsSingle()
                .WithArguments(_speed);

            Container.BindInterfacesTo<MovingPlatform>()
                .AsSingle();
        }
    }
}