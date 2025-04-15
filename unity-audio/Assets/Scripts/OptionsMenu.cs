using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public AudioMixer masterMixer;
    private bool previousInvertYState;
    private float previousBGMVolume;
     private float previousSFXVolume;
    private string previousScene;

    void Start()
    {
        // Save the previous scene so we can return to it
        previousScene = PlayerPrefs.GetString("PreviousScene", "MainMenu");

        // Load the stored Y inversion preference
        bool isInverted = PlayerPrefs.GetInt("InvertY", 0) == 1;
        invertYToggle.isOn = isInverted;
        previousInvertYState = isInverted;

        // Load and set the stored BGM volume
        float storedVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        bgmSlider.value = storedVolume;
        previousBGMVolume = storedVolume;
        SetBGMVolume(storedVolume);

        // Load and set the stored SFX volume
        float storedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        sfxSlider.value = storedSFXVolume;
        previousSFXVolume = storedSFXVolume;
        SetSFXVolume(storedSFXVolume);

        // Add listener for slider value changes
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void SetBGMVolume(float volume)
    {
        // Convert slider value (0 to 1) to decibels (-80dB to 0dB)
        float dB = volume > 0.0001f ? 20f * Mathf.Log10(volume) : -80f;
        masterMixer.SetFloat("BGMVolume", dB);
    }

    void SetSFXVolume(float volume)
    {
        // Convert slider value (0 to 1) to decibels (-80dB to 0dB)
        float dB = volume > 0.0001f ? 20f * Mathf.Log10(volume) : -80f;
        masterMixer.SetFloat("SFXVolume", dB);
    }

    public void Apply()
    {
        // Save Y inversion setting
        PlayerPrefs.SetInt("InvertY", invertYToggle.isOn ? 1 : 0);
        
        // Save BGM volume setting
        PlayerPrefs.SetFloat("BGMVolume", bgmSlider.value);
        PlayerPrefs.Save();

        // Save SFX volume setting
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.Save();

        SceneManager.LoadScene(previousScene);
    }

    public void Back()
    {
        // Restore previous states
        invertYToggle.isOn = previousInvertYState;
        SetBGMVolume(previousBGMVolume);
        SetSFXVolume(previousSFXVolume);
        
        SceneManager.LoadScene(previousScene);
    }
}