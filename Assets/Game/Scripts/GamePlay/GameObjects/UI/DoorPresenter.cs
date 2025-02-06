using System;
using Game.Content.Environment;
using Zenject;

namespace Game.UI
{
    public class DoorPresenter : IInitializable, IDisposable
    {
        private readonly IDoor _door;
        private readonly DoorView _view;

        public DoorPresenter(IDoor door, DoorView view)
        {
            _door = door;
            _view = view;
        }

        public void Initialize()
        {
            _door.Opened += OnDoorOpened;
            _door.Closed += OnDoorClosed;
            _door.KeyCollected += OnKeyCollected;
            _door.KeyCountChanged += OnKeyCountChanged;

            OnKeyCountChanged(0);
        }

        public void Dispose()
        {
            _door.Opened -= OnDoorOpened;
            _door.Closed -= OnDoorClosed;
            _door.KeyCollected -= OnKeyCollected;
            _door.KeyCountChanged -= OnKeyCountChanged;
        }

        private void OnKeyCountChanged(int count)
        {
            string text = $"{count}/{_door.KeyCount}";

            _view.ChangeKeysCount(text);
        }

        private void OnDoorOpened()
        {
            _view.Open();
        }

        private void OnDoorClosed()
        {
            _view.Close();
        }

        private void OnKeyCollected()
        {
            _view.PlayKeySound();
        }
    }
}