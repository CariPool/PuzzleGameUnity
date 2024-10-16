using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Method for Resume Button
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        gameObject.SetActive(false); // Hide the pause panel
    }

    // Method for Options Button (You can add logic here if you have an options menu)
    public void OpenOptions()
    {
        Debug.Log("Open Options Menu");
        // Logic to open options menu can be added here
    }

    // Method for Quit Button
    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        //Application.Quit(); // Quits the application. Won't work in the editor.
        // Or load the main menu:
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
