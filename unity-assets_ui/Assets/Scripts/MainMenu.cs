using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect(int level)
    {
        string sceneName = "Level0" + level;  // Example: Level01, Level02, Level03
        SceneManager.LoadScene(sceneName);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void ExitGame()
    {
        Debug.Log("Exited");  // Prints to console
        Application.Quit();
    }
}