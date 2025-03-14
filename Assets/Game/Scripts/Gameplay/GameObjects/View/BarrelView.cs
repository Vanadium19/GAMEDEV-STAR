using UnityEngine;

namespace Game.View
{
    public class BarrelView : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _barrelExplosionSound;

        public void OnBarrelExploded()
        {
            _audioSource.PlayOneShot(_barrelExplosionSound);
        }
    }
}
