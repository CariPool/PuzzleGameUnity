using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button creditsButton;
    public Button quitButton;
    public GameObject optionsPanel; // Reference to your options panel

    private void Start()
    {
        // Assign button functionality
        startButton.onClick.AddListener(StartGame);
        optionsButton.onClick.AddListener(ToggleOptions); // Modified to toggle the options panel
        creditsButton.onClick.AddListener(OpenCredits);
        quitButton.onClick.AddListener(QuitGame);

        // Load the saved level on start
        if (PlayerPrefs.HasKey("LastLevel"))
        {
            Debug.Log("Last level saved: " + PlayerPrefs.GetInt("LastLevel"));
        }
        else
        {
            Debug.Log("No saved level found, starting from level 1.");
        }

        // Ensure the options panel is hidden at the start
        if (optionsPanel != null)
        {
            optionsPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Options panel is not assigned in the Inspector.");
        }
    }

    public void StartGame()
    {
        // Load the saved level or default to level 1 if no saved level exists
        int lastLevel = PlayerPrefs.GetInt("LastLevel", 1);
        SceneManager.LoadScene("Level" + lastLevel);
    }

    public void ToggleOptions()
    {
        // Toggle the visibility of the options panel
        if (optionsPanel != null)
        {
            bool isActive = optionsPanel.activeSelf;
            optionsPanel.SetActive(!isActive); // Show/Hide the options panel
            Debug.Log("Toggling Options Panel: " + (!isActive ? "Opened" : "Closed"));
        }
    }

    public void OpenCredits()
    {
        // Load credits scene or show credits UI (implement as needed)
        Debug.Log("Open Credits");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public static void SaveLevel(int level)
    {
        PlayerPrefs.SetInt("LastLevel", level);
        PlayerPrefs.Save();
    }
}
