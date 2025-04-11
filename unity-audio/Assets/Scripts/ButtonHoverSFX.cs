using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class ButtonHoverSFX : MonoBehaviour, IPointerEnterHandler
{
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
            Debug.Log("Playing hover sound on " + gameObject.name);
        }
    }
}
