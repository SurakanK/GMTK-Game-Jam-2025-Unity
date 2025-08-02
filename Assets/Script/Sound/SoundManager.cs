using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private bool IsLoop = false;
    [SerializeField] private bool IsPlayonAwake = false;
    [SerializeField] private bool IsRandom = false;

    private AudioSource audioSource;

    void Awake()
    {
        // Singleton 
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Setup AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.loop = IsLoop;
        audioSource.playOnAwake = IsPlayonAwake;
    }

    void Start()
    {
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
