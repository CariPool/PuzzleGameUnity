using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    private Player player;
    private float horizontal, vertical;
    private GameObject pausePanel; // Reference to the pause panel UI
    private bool isPaused = false; // Tracks whether the game is paused

    void Start()
    {
        player = GetComponent<Player>();
        pausePanel = GameObject.Find("PausePanel");
        if (pausePanel != null)
        {
            pausePanel.SetActive(false); // Ensure the pause panel is hidden at the start
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Jump();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            player.Interact();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void FixedUpdate()
    {
        if (player != null)
            player.Move(new Vector2(horizontal, vertical));
    }

    // Method to toggle pause and the pause panel
    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game
            if (pausePanel != null)
            {
                pausePanel.SetActive(true); // Show the pause panel
            }
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            if (pausePanel != null)
            {
                pausePanel.SetActive(false); // Hide the pause panel
            }
        }
    }
}
