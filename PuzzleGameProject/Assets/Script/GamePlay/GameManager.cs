using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InteractableLever Lever01;
    public InteractableLever Lever02;

    public DoorExit levelExitDoor;

    private Player currentPlayer;



    public Player playerPrefabs;
    public Transform spawnPoint;

    private int leverActivated = 0;

    private bool isLever01ON = false;
    private bool isLever02ON = false;

    void Start()
    {
        Instantiate(playerPrefabs, spawnPoint.position, spawnPoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        CheckLeverActivation();
        OpenDoor();
    }

    private void CheckLeverActivation()
    {
        if (Lever01.IsOn() && !isLever01ON)
        {
            leverActivated++;
            isLever01ON = true;
            levelExitDoor.SetDoorStage(leverActivated);
            Debug.Log("Lever01 Is ON");
        }

        if (Lever02.IsOn() && !isLever02ON) 
        {
            leverActivated++;
            isLever02ON = true;
            levelExitDoor.SetDoorStage(leverActivated);
            Debug.Log("Level02 Is ON lever :" + leverActivated);
        }
    }

    private void OpenDoor()
    {
        if (Lever01.IsOn() && Lever02.IsOn()) 
        {
            levelExitDoor.OpenTheDoor();
        }
    }
}
