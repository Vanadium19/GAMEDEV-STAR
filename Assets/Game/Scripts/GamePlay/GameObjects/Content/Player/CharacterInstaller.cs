using Game.Core.Components;
using Game.View;
using UnityEngine;
using Zenject;

namespace Game.Content.Player
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _transform;

        [Header("Main Settings")] [SerializeField] private int _health = 5;
        [SerializeField] private float _speed = 5f;

        [Header("Jump Settings")] [SerializeField] private float _jumpForce = 12;
        [SerializeField] private float _jumpDelay = 0.5f;

        [Header("Ground Check Settings")] [SerializeField] private GroundCheckParams _groundCheckParams;

        [Header("View")] [SerializeField] private PlayerView _playerView;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Character>()
                .AsSingle()
                .NonLazy();

            //Components
            Container.Bind<Rigidbody2D>()
                .FromInstance(_rigidbody)
                .AsSingle();
            
            Container.Bind<Transform>()
                .FromInstance(_transform)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<GroundChecker>()
                .AsSingle()
                .WithArguments(_groundCheckParams);

            StateComponentsInstaller.Install(Container, _groundCheckParams, _health);
            MoveComponentsInstaller.Install(Container, _jumpForce, _jumpDelay, _speed);

            //Presenters
            Container.BindInterfacesTo<PlayerPresenter>()
                .AsSingle()
                .NonLazy();

            //View
            Container.Bind<PlayerView>()
                .FromInstance(_playerView)
                .AsSingle();
        }

        #region Debug

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            //Jump
            if (_groundCheckParams.Point == null)
                return;

            Gizmos.DrawWireCube(_groundCheckParams.Point.position, _groundCheckParams.OverlapSize);
        }

        #endregion
    }
}