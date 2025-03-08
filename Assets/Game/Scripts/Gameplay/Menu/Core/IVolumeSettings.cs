namespace Game.Menu.Core
{
    public interface IVolumeSettings
    {
        public float MusicVolume { get; }
        public float EffectsVolume { get; }

        public void SetMusicVolume(float volume);
        public void SetEffectsVolume(float volume);
    }
}