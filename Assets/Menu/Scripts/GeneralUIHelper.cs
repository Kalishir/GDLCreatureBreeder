using UnityEngine;
using System.Collections;

public class GeneralUIHelper : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    /// <summary>
    /// The start method
    /// </summary>
    private void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Quick and simple SFX Player for UI elements
    /// </summary>
    /// <param name="clip">
    /// The clip.
    /// </param>
    public void PlaySound(AudioClip clip)
    {
        this.audioSource.clip = clip;
        this.audioSource.Play();
    }



}
