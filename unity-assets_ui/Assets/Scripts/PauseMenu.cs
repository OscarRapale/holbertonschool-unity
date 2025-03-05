using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas; // Assign PauseCanvas in the Inspector
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

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        Debug.Log("Resume button clicked!");
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f; // Resume game time
        isPaused = false;
        
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
