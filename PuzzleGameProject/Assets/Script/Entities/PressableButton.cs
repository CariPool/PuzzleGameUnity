using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableButton : PressabableObject
{
    public Transform button;

    [SerializeField] private float pressedOffsetY = -0.2f; // Offset for the pressed position
    private float speed = 5.0f;
    private AudioSource _audioSource;

    public AudioClip buttonPressedSound;
    public AudioClip buttonReleasedSound;

    private int objectPressing = 0;
    private Vector3 originalPosition; // Store the original position of the button

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        originalPosition = button.position; // Initialize original position
    }

    // Update is called once per frame
    void Update()
    {
        // Determine the target Y position relative to the original position
        float targetY = IsPressed() ? originalPosition.y + pressedOffsetY : originalPosition.y;

        Vector3 currentPosition = button.position;
        Vector3 targetPosition = new Vector3(originalPosition.x, targetY, originalPosition.z);

        // Smoothly interpolate the button's position to the target position
        button.position = Vector3.Lerp(currentPosition, targetPosition, speed * Time.deltaTime);
    }

    public override bool IsPressed()
    {
        return base.IsPressed();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectPressing++;

        if (objectPressing == 1)
        {
            SetIsPressed(true);
            _audioSource.PlayOneShot(buttonPressedSound);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectPressing--;

        if (objectPressing == 0)
        {
            SetIsPressed(false);
            _audioSource.PlayOneShot(buttonReleasedSound);
        }
    }
}
