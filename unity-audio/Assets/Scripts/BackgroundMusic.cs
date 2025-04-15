using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip level01Music;  // CheeryMonday
    public AudioClip level02Music;  // PorchSwingDays
    public AudioClip level03Music;  // BrittleRille
    public AudioMixerGroup bgmMixerGroup;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = true;
        audioSource.outputAudioMixerGroup = bgmMixerGroup;

        // Set music based on current scene
        string sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "Level01":
                audioSource.clip = level01Music;
                break;
            case "Level02":
                audioSource.clip = level02Music;
                break;
            case "Level03":
                audioSource.clip = level03Music;
                break;
        }

        audioSource.Play();
    }

    public void StopMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}