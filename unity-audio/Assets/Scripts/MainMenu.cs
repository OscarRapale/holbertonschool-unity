using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        BackgroundMusic bgm = FindObjectOfType<BackgroundMusic>();
        if (bgm != null)
        {
            bgm.StopMusic();
        }
    }
    public void LevelSelect(int level)
    {
        string sceneName = "Level0" + level;
        SceneManager.LoadScene(sceneName);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void ExitGame()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}