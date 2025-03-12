using UnityEngine;

namespace Game.View
{
    public class SlowZoneView : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _slowZoneSound;

        public void OnSlowZoneDeathStatusChanged(bool value)
        {
            if (value)
            {
                _audioSource.Stop();
                _audioSource.loop = false;
                _audioSource.clip = null;
                return;
            }

            _audioSource.clip = _slowZoneSound;
            _audioSource.loop = true;
            _audioSource.Play();
        }
    }
}