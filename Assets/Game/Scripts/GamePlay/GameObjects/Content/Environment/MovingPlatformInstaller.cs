using Game.Content.Environment;
using Game.Controllers;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Installers
{
    public class MovingPlatformInstaller : MonoInstaller
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private float _speed = 2;
        [SerializeField] private Transform _startPosition;
        [SerializeField] private Transform _endPosition;

        public override void InstallBindings()
        {
            Container.Bind<Transform>()
                .FromInstance(_transform)
                .AsCached();

            Container.BindInterfacesTo<PatrolComponent>()
                .AsSingle()
                .WithArguments(_startPosition.position, _endPosition.position, _speed);
        }
    }
}