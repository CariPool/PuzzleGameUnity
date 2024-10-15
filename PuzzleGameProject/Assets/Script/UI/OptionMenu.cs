using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public Slider soundSlider; // Reference to the sound slider
    public Button closeButton; // Reference to the close button

    private void Start()
    {
        // Initialize slider and button
        soundSlider.onValueChanged.AddListener(AdjustSoundVolume);
        closeButton.onClick.AddListener(CloseOptionsMenu);

        // Set the slider to match the current volume level
        soundSlider.value = AudioListener.volume;
    }

    // Method to adjust the sound volume
    private void AdjustSoundVolume(float volume)
    {
        AudioListener.volume = volume;
        Debug.Log("Volume set to: " + volume);
    }

    // Method to close the options menu
    private void CloseOptionsMenu()
    {
        gameObject.SetActive(false); // Hide the options panel
        Debug.Log("Options menu closed.");
    }
}
