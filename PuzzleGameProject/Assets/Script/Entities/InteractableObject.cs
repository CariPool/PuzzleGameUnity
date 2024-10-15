using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public GameObject Interacter { get; set; }

    public abstract void Interact();

    

}
