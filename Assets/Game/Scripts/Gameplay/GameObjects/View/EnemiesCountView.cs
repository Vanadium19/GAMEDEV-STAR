using TMPro;
using UnityEngine;

namespace Game.View
{
    public class EnemiesCountView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _count;

        public void ShowEnemiesCount(string text)
        {
            _count.text = text;
        }
    }
}