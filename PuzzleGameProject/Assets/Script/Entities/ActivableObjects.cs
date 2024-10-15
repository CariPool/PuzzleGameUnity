using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableObjects : MonoBehaviour
{
    public PressableButton buttonToToggle;   // The button that controls this activable object

    protected bool isActive = false;         // Tracks whether the object is currently active

    void Update()
    {
        // Check if the button is pressed
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

    // Virtual method to activate the object (can be overridden in subclasses)
    protected virtual void ActivateObject()
    {
            
            isActive = true;  // Mark it as active
            Debug.Log("Object Activated");
        
    }

    // Virtual method to deactivate the object (can be overridden in subclasses)
    protected virtual void DeactivateObject()
    {
       
            
            isActive = false;  // Mark it as inactive
            Debug.Log("Object Deactivated");
        
    }
}
