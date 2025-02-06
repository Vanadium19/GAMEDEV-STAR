using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.App.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly string _filePath = $"{Application.persistentDataPath}/GameState.txt";

        public void SetState(Dictionary<string, string> state)
        {
            var json = JsonConvert.SerializeObject(state);

            File.WriteAllText(_filePath, json);
        }

        public Dictionary<string, string> GetState()
        {
            if (!File.Exists(_filePath))
                return new Dictionary<string, string>();
            
            var json = File.ReadAllText(_filePath);

            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }
    }
}