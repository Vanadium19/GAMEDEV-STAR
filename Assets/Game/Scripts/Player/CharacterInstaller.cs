using Game.Components;
using Game.Player.Installers;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private Character _character;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _transform;
        [SerializeField] private UnityEventReceiver _unityEvents;

        [Header("Main Settings")] [SerializeField] private int _health = 5;
        [SerializeField] private float _speed = 5f;

        [Header("Jump Settings")] [SerializeField] private float _jumpForce = 12;
        [SerializeField] private float _jumpDelay = 0.5f;

        [Header("Ground Check Settings")] [SerializeField] private GroundCheckParams _groundCheckParams;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Character>()
                .FromInstance(_character)
                .AsSingle();

            //Components
            Container.Bind<Rigidbody2D>()
                .FromInstance(_rigidbody)
                .AsSingle();

            Container.Bind<UnityEventReceiver>()
                .FromInstance(_unityEvents)
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<GroundChecker>()
                .AsSingle()
                .WithArguments(_groundCheckParams);

            StateComponentsInstaller.Install(Container, _groundCheckParams, _health);
            MoveComponentsInstaller.Install(Container, _transform, _jumpForce, _jumpDelay, _speed);
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