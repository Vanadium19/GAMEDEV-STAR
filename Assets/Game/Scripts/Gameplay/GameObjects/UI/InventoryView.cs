using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Image _image;

        [SerializeField] private TMP_Text _ammoCount;
        [SerializeField] private GameObject _ammoPanel;

        public void ChangeWeapon(Sprite weapon)
        {
            _image.sprite = weapon;
        }

        public void EnableAmmoPanel(bool value)
        {
            _ammoPanel.SetActive(value);
        }

        public void SetAmmoCount(string count)
        {
            _ammoCount.text = count;
        }
    }
}