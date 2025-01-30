using Game.Components;
using Game.Obstacles.Environment;
using UnityEngine;
using Zenject;

namespace Game.Obstacles.Installers
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