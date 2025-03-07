using Game.Scripts.Common;
using UnityEngine.SceneManagement;

namespace Game.Menu.Core
{
    public class LevelLoader : ILevelLoader
    {
        private const int MAX_LEVEL_NUMBER = (int)SceneNumbers.Level6;

        private int _level;

        public void LoadLevel()
        {
            if (_level > MAX_LEVEL_NUMBER)
            {
                _level = (int)SceneNumbers.Level1;
                SceneManager.LoadScene((int)SceneNumbers.Menu);
                return;
            }

            SceneManager.LoadScene(_level);
        }

        public void SetNextLevel()
        {
            _level++;
        }
    }

}