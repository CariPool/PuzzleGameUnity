using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableButton : PressabableObject
{

    public Transform button;

    

    [SerializeField]private float pressedY = -0.2f;
    [SerializeField]private float normalY = 0.0f;
    private float speed = 5.0f;

    private AudioSource _audioSource;

    public AudioClip buttonPressedSound;
    public AudioClip buttonReleasedSound;

    private int objectPressing = 0;



    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

    }

    
    // Update is called once per frame
    void Update()
    {
        float targetY = IsPressed() ? pressedY : normalY;

        Vector3 currentPosition = button.position;

        Vector3 targetPosition = new Vector3(currentPosition.x, targetY, currentPosition.z);
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
