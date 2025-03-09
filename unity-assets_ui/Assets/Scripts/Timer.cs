using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float elapsedTime = 0f;
    public TextMeshProUGUI finalTimeText; // Store the reference to FinalTime
    public bool isRunning { get; private set; }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100) % 100);
        TimerText.text = string.Format("{0}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void Win() // This will display the time on WinCanvas
    {
        if (!isRunning)
        {
            finalTimeText.text = TimerText.text;
        }
    }
}
