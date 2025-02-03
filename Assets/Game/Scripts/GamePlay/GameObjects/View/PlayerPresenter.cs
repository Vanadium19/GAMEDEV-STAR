using System;
using Game.Content.Player;
using UniRx;
using Zenject;

namespace Game.View
{
    public class PlayerPresenter : IInitializable, IDisposable
    {
        private readonly Character _character;
        private readonly PlayerView _playerView;

        private CompositeDisposable _disposable = new();

        public PlayerPresenter(Character character, PlayerView playerView)
        {
            _character = character;
            _playerView = playerView;
        }

        public void Initialize()
        {
            _character.Died.Subscribe(OnCharacterDied).AddTo(_disposable);
            _character.IsMoving.Subscribe(SetMovingState).AddTo(_disposable);
            _character.IsFalling.Subscribe(SetFallingState).AddTo(_disposable);
            _character.Jumped.Subscribe(unit => Jump()).AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }

        private void OnCharacterDied(Action callback)
        {
            _playerView.Die(callback);
        }

        private void SetMovingState(bool value)
        {
            _playerView.SetMovingState(value);
        }

        private void SetFallingState(bool value)
        {
            _playerView.SetFallingState(value);
        }

        private void Jump()
        {
            _playerView.Jump();
        }
    }
}