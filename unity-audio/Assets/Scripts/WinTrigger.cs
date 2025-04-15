using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class WinTrigger : MonoBehaviour {

    public Timer timer;
    public Text timerText;
    public GameObject winCanvas; // Reference to WinCanvas
    public AudioClip victoryMusic;
    public AudioMixerGroup bgmMixerGroup;
    private AudioSource victoryAudioSource;
    private BackgroundMusic bgm;

    void Start()
    {
        bgm = FindObjectOfType<BackgroundMusic>();

        // Setup victory audio source
        victoryAudioSource = gameObject.AddComponent<AudioSource>();
        victoryAudioSource.clip = victoryMusic;
        victoryAudioSource.loop = false;
        victoryAudioSource.playOnAwake = false;
        victoryAudioSource.outputAudioMixerGroup = bgmMixerGroup;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if player touches WinFlag
        {
            timer.StopTimer(); // Stop the timer
            timer.Win(); // Update final time in WinCanvas

            if (bgm != null)
            {
                bgm.StopMusic();
            }

            // Play victory music
            if (victoryAudioSource != null)
            {
                victoryAudioSource.Play();
            }

            // Activate the win screen
            winCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
