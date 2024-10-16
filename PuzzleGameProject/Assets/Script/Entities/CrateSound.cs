using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
public class CrateSound : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private AudioSource _audioSource;
    [SerializeField] private float movementThreshold = 0.1f; // Minimum speed to trigger sound
    [SerializeField] private float volume = 0.5f; // Volume of the sound

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true; // Set the audio source to loop the sound
        _audioSource.volume = volume;
    }

    private void Update()
    {
        // Check if the crate is moving based on its velocity
        if (_rigidbody2D.velocity.magnitude > movementThreshold && !_audioSource.isPlaying)
        {
            // If the crate is moving and sound is not playing, start the sound
            _audioSource.Play();
        }
        else if (_rigidbody2D.velocity.magnitude <= movementThreshold && _audioSource.isPlaying)
        {
            // If the crate stops moving, stop the sound
            _audioSource.Stop();
        }
    }
}
