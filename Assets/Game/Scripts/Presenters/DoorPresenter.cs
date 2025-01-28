using System;
using Game.Obstacles.Environment;
using Game.UI.Obstacles;
using Zenject;

namespace Game.Presenters
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
        }

        public void Dispose()
        {
            _door.Opened -= OnDoorOpened;
            _door.Closed -= OnDoorClosed;
        }

        private void OnDoorOpened()
        {
            _view.Open();
        }

        private void OnDoorClosed()
        {
            _view.Close();
        }
    }
}