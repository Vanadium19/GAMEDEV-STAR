using Game.Obstacles.Environment;
using Game.UI.Obstacles;
using Zenject;

namespace Game.Presenters
{
    public class KeysPresenter : IInitializable
    {
        private readonly Key[] _keys;
        private readonly KeysView _view;

        public KeysPresenter(Key[] keys, KeysView view)
        {
            _keys = keys;
            _view = view;
        }

        public void Initialize()
        {
            foreach (var key in _keys)
                key.Collected += OnKeyCollected;
        }

        private void OnKeyCollected(Key key)
        {
            _view.AddKey();

            key.Lost += OnKeyLost;
            key.Collected -= OnKeyCollected;
        }

        private void OnKeyLost(Key key)
        {
            _view.RemoveKey();
            
            key.Lost -= OnKeyLost;
            key.Collected += OnKeyCollected;
        }
    }
}