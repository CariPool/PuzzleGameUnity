using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressabableObject : MonoBehaviour
{
    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public virtual bool IsPressed()
    {
        return isPressed;
    }

    public virtual void SetIsPressed(bool value)
    {
        isPressed = value;
    }

}
