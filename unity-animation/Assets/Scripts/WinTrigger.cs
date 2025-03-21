using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour {

    public Timer timer;
    public Text timerText;
    public GameObject winCanvas; // Reference to WinCanvas

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player reached WinFlag!");
        if (other.CompareTag("Player")) // Check if player touches WinFlag
        {
            timer.StopTimer(); // Stop the timer
            timer.Win(); // Update final time in WinCanvas

            // Activate the win screen
            winCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
