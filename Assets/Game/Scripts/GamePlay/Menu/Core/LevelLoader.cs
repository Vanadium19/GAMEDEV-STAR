using Game.Scripts.Common;
using UnityEngine.SceneManagement;

namespace Game.Menu.Core
{
    public class LevelLoader : ILevelLoader
    {
        private readonly int _maxLevel = (int)SceneNumber.Level3;

        private int _level = (int)SceneNumber.Level0;

        public int Level => _level;

        public void SetLevel(int level)
        {
            _level = level;
        }

        public void LoadLevel()
        {
            if (_level > _maxLevel)
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
    }
}