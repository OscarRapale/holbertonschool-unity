using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float elapsedTime = 0f;
    public bool isRunning { get; private set; }

    void Update()
    {
        if (isRunning)
        {
            Debug.Log("Timer is running");
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
        Debug.Log("Timer started");
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false; // Stop the timer
    }
}
