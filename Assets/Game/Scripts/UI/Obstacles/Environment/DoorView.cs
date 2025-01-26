using System;
using UnityEngine;

namespace Game.UI.Obstacles
{
    public class DoorView : MonoBehaviour
    {
        public void Open()
        {
            gameObject.SetActive(false);
        }
    }
}