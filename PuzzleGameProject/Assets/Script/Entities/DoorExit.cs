using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit : InteractableObject
{
    private bool doorIsOpen;

    private int doorStage = 0;



    private Animator _animator;


    public string nextLevelName;

    private void Start()
    {
        _animator = GetComponent<Animator>();

    }

    public override void Interact()
    {
        if (!doorIsOpen)
        {
            Debug.Log("The door is closed.");
            return;
        }

        if (string.IsNullOrEmpty(nextLevelName))
        {
            Debug.LogError("Next level name is not set.");
            return;
        }

        Debug.Log("Level Finished");
        SceneManager.LoadScene(nextLevelName);
    }

    public void OpenTheDoor()
    {
        doorIsOpen = true;

    }

    public void SetDoorStage(int doorStage)
    {
        this.doorStage = doorStage;
        _animator.SetInteger("Stage", doorStage);

        Debug.Log($"[DOOR EXIT] - doorStage is now {doorStage}");
        
    }

}
