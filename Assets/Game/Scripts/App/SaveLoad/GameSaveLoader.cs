using System.Collections.Generic;
using Game.App.Repository;
using Zenject;

namespace Game.App.SaveLoad
{
    public class GameSaveLoader : IGameSaveLoader, IInitializable
    {
        private readonly IGameRepository _repository;
        private readonly IGameSerializer[] _serializers;

        public GameSaveLoader(IGameRepository repository, IGameSerializer[] serializers)
        {
            _repository = repository;
            _serializers = serializers;
        }

        public void Initialize()
        {
            Load();
        }

        public void Save()
        {
            var state = new Dictionary<string, string>();

            foreach (var serializer in _serializers)
                serializer.Serialize(state);

            _repository.SetState(state);
        }

        public void Load()
        {
            Dictionary<string, string> state = _repository.GetState();

            foreach (var serializer in _serializers)
                serializer.Deserialize(state);
        }
    }
}