using System.Collections.Generic;

namespace Game.App.SaveLoad
{
    public interface IGameSerializer
    {
        public void Serialize(IDictionary<string, string> state);

        public void Deserialize(IDictionary<string, string> state);
    }
}