using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;
    private bool previousInvertYState;
    private string previousScene;

    void Start()
    {
        // Save the previous scene so we can return to it
        previousScene = PlayerPrefs.GetString("PreviousScene", "MainMenu");

        // Load the stored preference
        bool isInverted = PlayerPrefs.GetInt("InvertY", 0) == 1;
        invertYToggle.isOn = isInverted;

        // Store previous state in case the player presses Back
        previousInvertYState = isInverted;
    }

    public void Apply()
    {
        // Save the new setting
        PlayerPrefs.SetInt("InvertY", invertYToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();

        // Load the previous scene
        SceneManager.LoadScene(previousScene);
    }

    public void Back()
    {
        // Restore previous state and return without saving changes
        invertYToggle.isOn = previousInvertYState;
        SceneManager.LoadScene(previousScene);
    }
}
