using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private bool IsLoop = false;
    [SerializeField] private bool IsPlayonAwake = false;
    [SerializeField] private bool IsRandom = false;
    private AudioSource audioSource;

    void Awake()
    {
        // Ensure AudioSource is attached
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Apply loop and playOnAwake settings
        audioSource.loop = IsLoop;
        audioSource.playOnAwake = IsPlayonAwake;
    }

    void Start()
    {
        // Play a clip if GameObject is active and playOnAwake is true
        if (gameObject.activeInHierarchy && audioClips.Length > 0 && IsPlayonAwake)
        {
            if (IsRandom) PlayRandomClip();
            else PlayFirstClip();
        }
    }

    public void PlayRandomClip()
    {
        int index = Random.Range(0, audioClips.Length);
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    public void PlayFirstClip()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    public void PlayClip(int index)
    {
        if (index >= 0 && index < audioClips.Length)
        {
            audioSource.clip = audioClips[index];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("SoundManager: Index out of bounds.");
        }
    }
}
