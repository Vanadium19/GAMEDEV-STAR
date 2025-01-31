using System;
using Game.Player;
using Game.Scripts.View;
using Zenject;

namespace Game.Presenters
{
    public class PlayerPresenter : IInitializable, IDisposable
    {
        private readonly Character _character;
        private readonly PlayerView _playerView;

        public PlayerPresenter(Character character, PlayerView playerView)
        {
            _character = character;
            _playerView = playerView;
        }

        public void Initialize()
        {
            _character.Died += OnCharacterDied;
        }

        public void Dispose()
        {
            _character.Died -= OnCharacterDied;
        }

        private void OnCharacterDied(Action callback)
        {
            _playerView.Die(callback);
        }
    }
}