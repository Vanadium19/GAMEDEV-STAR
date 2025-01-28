using UnityEngine;

namespace Game.UI.Obstacles
{
    public class DoorView : MonoBehaviour
    {
        public void Open()
        {
            gameObject.SetActive(false);
        }

        public void Close()
        {
            gameObject.SetActive(true);
        }
    }
}