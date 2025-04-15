using UnityEngine;
using UnityEngine.Audio;

public class AmbientSound : MonoBehaviour
{
    public AudioClip ambientClip;
    public AudioMixerGroup ambienceMixerGroup;
    public float maxDistance = 20f;
    public float minDistance = 2f;
    private AudioSource audioSource;
    private Transform player;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = ambientClip;
        audioSource.loop = true;
        audioSource.playOnAwake = true;
        audioSource.spatialBlend = 1f; // Full 3D sound
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.maxDistance = maxDistance;
        audioSource.minDistance = minDistance;
        audioSource.outputAudioMixerGroup = ambienceMixerGroup;
        
        // Find the player
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        audioSource.Play();
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            float volume = 1 - (distance / maxDistance);
            volume = Mathf.Clamp(volume, 0f, 1f);
            audioSource.volume = volume;
        }
    }
}