using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EasterEgg : MonoBehaviour
{
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _audio.Play();
    }
}