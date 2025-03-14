using UnityEngine;

namespace Game.View
{
    public class MineView : MonoBehaviour
    {

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _mineExplosionSound;

        public void OnMineExploded()
        {
            _audioSource.PlayOneShot(_mineExplosionSound);
        }
    }
}