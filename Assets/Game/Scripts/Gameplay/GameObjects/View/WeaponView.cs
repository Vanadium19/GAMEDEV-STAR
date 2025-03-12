using UnityEngine;

namespace Game.View
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _weaponShootSound;

        public void OnWeaponShoot()
        {
            _audioSource.PlayOneShot(_weaponShootSound);
        }
    }

}
