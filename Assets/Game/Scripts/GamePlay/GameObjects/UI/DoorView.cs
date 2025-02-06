using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class DoorView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _keysCount;
        [SerializeField] private BoxCollider2D _collider;

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _closeImage;
        [SerializeField] private Sprite _openImage;

        public void Open()
        {
            _collider.enabled = false;
            _spriteRenderer.sprite = _openImage;
        }

        public void Close()
        {
            _collider.enabled = true;
            _spriteRenderer.sprite = _closeImage;
        }

        public void ChangeKeysCount(string text)
        {
            _keysCount.text = text;
        }
    }
}