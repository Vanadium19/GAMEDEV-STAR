using Game.App.SaveLoad;

namespace Game.Menu
{
    public class MenuFacade
    {
        private readonly IGameSaveLoader _gameSaveLoader;
        private readonly IGameSettings _gameSettings;
        private readonly ILevelLoader _levelLoader;

        public MenuFacade(IGameSaveLoader gameSaveLoader,
            IGameSettings gameSettings,
            ILevelLoader levelLoader)
        {
            _gameSaveLoader = gameSaveLoader;
            _gameSettings = gameSettings;
            _levelLoader = levelLoader;
        }

        public void LoadGame()
        {
            _levelLoader.LoadLevel();
        }

        public void SetVolume(float volume)
        {
            _gameSettings.SetVolume(volume);
            _gameSaveLoader.Save();
        }

        public void LoadNextLevel()
        {
            _levelLoader.SetNextLevel();
            _levelLoader.LoadLevel();
            _gameSaveLoader.Save();
        }
    }
}