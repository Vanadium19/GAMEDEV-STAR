using Game.Scripts.Common;
using UnityEngine.SceneManagement;

namespace Game.Menu.Core
{
    public class LevelLoader : ILevelLoader
    {
        private const int MaxLevelNumber = (int)SceneNumber.Level6;

        private int _level = (int)SceneNumber.Level1;

        public int Level => _level;

        public void LoadLevel()
        {
            if (_level > MaxLevelNumber)
            {
                _level = (int)SceneNumber.Level1;
                SceneManager.LoadScene((int)SceneNumber.Menu);
                return;
            }

            SceneManager.LoadScene(_level);
        }

        public void SetNextLevel()
        {
            _level++;
        }

        public void SetLevel(int level)
        {
            _level = level;
        }
    }
}