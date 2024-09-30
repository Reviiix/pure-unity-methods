using System.Collections.Generic;
using pure_unity_methods;
using UnityEngine;
using UnityEngine.UI;

namespace pure_unity_methods
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class AudioManager : Singleton<AudioManager>
{
    private static AudioSource _backGroundAudioSource;
    private static readonly Queue<AudioSource> AudioSources = new ();
    [SerializeField] private int maximumAudioSources;
    [SerializeField] private GameObject audioSourcePrefab;
    [SerializeField] private AudioClip buttonClick;

    public void Initialise()
    {
        ResolveDependencies();
        AssignAllButtonsTheClickSound();
        PlayBackgroundMusic();
    }

    private void ResolveDependencies()
    {
        _backGroundAudioSource = GetComponent<AudioSource>(); //Secured by the require component attribute.
        EmptyQueue();
        for (var i = 0; i < maximumAudioSources; i++)
        {
            AudioSources.Enqueue(Instantiate(audioSourcePrefab, transform).GetComponent<AudioSource>());
        }
    }
    
    private static void EmptyQueue()
    {
        var itemsInQueue = AudioSources.Count;
        for (var i = 0; i < itemsInQueue; i++)
        {
            AudioSources.Dequeue();
        }
    }

    private static void AssignAllButtonsTheClickSound()
    {
        var allButtons = FindObjectsOfType<Button>();
        foreach (var button in allButtons)
        {
            button.onClick.RemoveListener(PlayButtonClickSound); //Avoid any risk of duplicate sounds.
            button.onClick.AddListener(PlayButtonClickSound);
        }
    }
    
    private static void PlayBackgroundMusic()
    {
        _backGroundAudioSource.Play();
    }
    
    private static void PlayButtonClickSound()
    {
        PlayClip(Instance.buttonClick);
    }

    protected static void PlayClip(AudioClip clip)
    {
        if (!Instance) return;
        var audioSource = ReturnFirstUnusedAudioSource();
        audioSource.clip = clip;
        audioSource.Play();
    }

    private static AudioSource ReturnFirstUnusedAudioSource()
    {
        var audioSource = AudioSources.Dequeue();
        if (audioSource.isPlaying)
        {
            Debug.LogWarning($"{nameof(maximumAudioSources)} is set too low to play that many audio sources at once.");
        }
        AudioSources.Enqueue(audioSource);
        return audioSource;
    }
}
}
