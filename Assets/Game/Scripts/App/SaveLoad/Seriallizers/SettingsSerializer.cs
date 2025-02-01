using Game.App.Data;
using Game.Menu;

namespace Game.App.SaveLoad
{
    public class SettingsSerializer : GameSerializer<GameSettings, SettingsData>
    {
        protected override SettingsData Serialize(GameSettings service)
        {
            return new SettingsData { Volume = service.Volume };
        }

        protected override void Deserialize(GameSettings service, SettingsData data)
        {
            service.SetVolume(data.Volume);
        }
    }
}