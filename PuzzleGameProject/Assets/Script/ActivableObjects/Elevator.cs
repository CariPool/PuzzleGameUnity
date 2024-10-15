using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : ActivableObjects
{
    private Vector3 offPosition;         // Original position of the elevator
    public Vector3 onPositionOffsets;    // Offset to move the elevator when activated
    private Vector3 targetPosition;      // Target position for the elevator to move towards

    private float speed = 2f;            // Speed of the transition
    private bool isMoving = false;       // Tracks whether the elevator is currently moving

    void Start()
    {
        // Store the original position of the elevator
        offPosition = transform.position;

        // Initialize the target position as the off position
        targetPosition = offPosition;
    }

    void Update()
    {
        // If the elevator is moving, smoothly move towards the target position
        if (isMoving)
        {
            // Lerp between the current position and the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

            // Stop moving once the elevator reaches (or is close to) the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isMoving = false;  // Stop moving once the target position is reached
            }
        }

        if (buttonToToggle.IsPressed() && !isActive)
        {
            ActivateObject();
        }
        // If the button is no longer pressed and the object is active, deactivate it
        else if (!buttonToToggle.IsPressed() && isActive)
        {
            DeactivateObject();
        }

        
    }

    // Override the method to smoothly move the elevator to the on position
    protected override void ActivateObject()
    {
        base.ActivateObject();

        // Set the target position to the "on" position (current position + offset)
        targetPosition = offPosition + onPositionOffsets;

        // Start moving towards the target position
        isMoving = true;

        Debug.Log("Elevator Activated: Moving to On Position.");
    }

    // Override the method to smoothly move the elevator back to the off position
    protected override void DeactivateObject()
    {
        base.DeactivateObject();

        // Set the target position to the original "off" position
        targetPosition = offPosition;

        // Start moving towards the target position
        isMoving = true;

        Debug.Log("Elevator Deactivated: Returning to Off Position.");
    }
}
