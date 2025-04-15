using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public AudioMixer masterMixer; // Add reference to your AudioMixer
    public AudioMixerSnapshot normalSnapshot; // Normal game audio
    public AudioMixerSnapshot muffledSnapshot; // Paused/muffled audio
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f; // Pause game time
        isPaused = true;

        // Transition to muffled audio
        muffledSnapshot.TransitionTo(0.01f);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f; // Resume game time
        isPaused = false;

        // Transition back to normal audio
        normalSnapshot.TransitionTo(0.1f);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Restart() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Options() {
        PlayerPrefs.SetInt("PreviousScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
