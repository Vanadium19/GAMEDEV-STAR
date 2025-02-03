using Game.App.Data;
using Game.Menu.Core;

namespace Game.App.SaveLoad
{
    public class LevelLoaderSerializer : GameSerializer<LevelLoader, LevelLoaderData>
    {
        protected override LevelLoaderData Serialize(LevelLoader service)
        {
            return new LevelLoaderData { Level = service.Level };
        }

        protected override void Deserialize(LevelLoader service, LevelLoaderData data)
        {
            service.SetLevel(data.Level);
        }
    }
}