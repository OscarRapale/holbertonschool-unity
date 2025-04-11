using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClickSFX : MonoBehaviour
{
    private AudioSource audioSource;
    private Button button;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        button = GetComponent<Button>();
        
        if (button != null)
        {
            button.onClick.AddListener(PlayClickSound);
        }
    }

    private void PlayClickSound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
            Debug.Log("Playing click sound on " + gameObject.name);
        }
    }
}