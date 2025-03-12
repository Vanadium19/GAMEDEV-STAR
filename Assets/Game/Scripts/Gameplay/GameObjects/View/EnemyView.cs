using UnityEngine;

namespace Game.View
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _enemyWalkSound;
        [SerializeField] private AudioClip _enemyDeathSound;

        public void OnEnenmyWalk(bool value)
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
            
            _audioSource.clip = _enemyWalkSound;
            _audioSource.loop = true;
            _audioSource.Play();
        }

        public void OnEnemyDie(bool value)
        {
            _audioSource.PlayOneShot(_enemyDeathSound);
        }
    }
}