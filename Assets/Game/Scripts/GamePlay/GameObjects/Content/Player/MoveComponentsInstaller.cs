using Game.Core.Components;
using Zenject;

namespace Game.Content.Player
{
    public class MoveComponentsInstaller : Installer<float, float, float, MoveComponentsInstaller>
    {
        private readonly float _jumpForce;
        private readonly float _jumpDelay;
        private readonly float _speed;

        public MoveComponentsInstaller(float jumpForce, float jumpDelay, float speed)
        {
            _jumpForce = jumpForce;
            _jumpDelay = jumpDelay;
            _speed = speed;
        }

        public override void InstallBindings()
        {
            Container.Bind<Mover>()
                .AsSingle()
                .WithArguments(_speed);

            Container.BindInterfacesAndSelfTo<Jumper>()
                .AsSingle()
                .WithArguments(_jumpForce, _jumpDelay);

            Container.Bind<Rotater>()
                .AsSingle();
        }
    }
}