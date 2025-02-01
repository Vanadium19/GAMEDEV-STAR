using Game.App.SaveLoad;
using Game.Menu;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class Tester : MonoBehaviour
    {
        private GameSettings _settings;
        private IGameSaveLoader _saveLoader;

        [Inject]
        public void Construct(IGameSaveLoader saveLoader, GameSettings settings)
        {
            _settings = settings;
            _saveLoader = saveLoader;
        }

        [ContextMenu(nameof(UpVolume))]
        public void UpVolume()
        {
            _settings.SetVolume(1f);
            _saveLoader.Save();
        }

        [ContextMenu(nameof(DownVolume))]
        public void DownVolume()
        {
            _settings.SetVolume(0f);
            _saveLoader.Save();
        }


        [ContextMenu(nameof(DebugVolume))]
        public void DebugVolume()
        {
            Debug.Log($"Volume: {AudioListener.volume}");
        }
    }
}