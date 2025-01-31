using TMPro;
using UnityEngine;

namespace Game.UI.Obstacles
{
    public class DoorView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _keysCount;

        public void Open()
        {
            gameObject.SetActive(false);
        }

        public void Close()
        {
            gameObject.SetActive(true);
        }

        public void ChangeKeysCount(string text)
        {
            _keysCount.text = text;
        }
    }
}