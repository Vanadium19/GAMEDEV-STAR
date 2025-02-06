using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class DoorView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _keysCount;
        [SerializeField] private BoxCollider2D _collider;

        [Header("Image Settings")]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _closeImage;
        [SerializeField] private Sprite _openImage;
        
        [Header("Audio Settings")]
        [SerializeField] private AudioSource _audio;
        [SerializeField] private AudioClip _openSound;
        [SerializeField] private AudioClip _keySund;

        public void Open()
        {
            _collider.enabled = false;
            _spriteRenderer.sprite = _openImage;
            _audio.PlayOneShot(_openSound);
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

        public void PlayKeySound()
        {
            _audio.PlayOneShot(_keySund);
        }
    }
}