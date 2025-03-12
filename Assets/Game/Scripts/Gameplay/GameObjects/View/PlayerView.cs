using UnityEngine;

namespace Game.View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _playerWalkSound;
        [SerializeField] private AudioClip _playerDeathSound;

        public void OnPlayerMove(bool value)
        {
            if (!value)
            {
                _audioSource.Stop();
                _audioSource.loop = false;
                _audioSource.clip = null;
                return;
            }

            if (_audioSource.isPlaying)
                return;

            _audioSource.clip = _playerWalkSound;
            _audioSource.loop = true;
            _audioSource.Play();
        }

        public void OnPlayerDie(bool value)
        {
            _audioSource.PlayOneShot(_playerDeathSound);
        }
    }
}