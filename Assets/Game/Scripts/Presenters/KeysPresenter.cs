using Game.Obstacles.Environment;
using Game.UI.Obstacles;
using Zenject;

namespace Game.Presenters
{
    public class KeysPresenter : IInitializable
    {
        private readonly Key[] _keys;
        private readonly KeyView _view;

        public KeysPresenter(Key[] keys, KeyView view)
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

            key.Collected -= OnKeyCollected;
        }
    }
}