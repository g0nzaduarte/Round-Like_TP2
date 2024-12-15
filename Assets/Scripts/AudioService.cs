using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoBehaviour, IAudioService
{
    public List<AudioClip> soundClips;
    private Dictionary<string, AudioClip> soundDictionary;
    private AudioSource audioSource;

    private void Awake()
    {
        
        soundDictionary = new Dictionary<string, AudioClip>();
        foreach (var clip in soundClips)
        {
            soundDictionary[clip.name] = clip;
        }

        
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound(string soundName)
    {
        if (soundDictionary.ContainsKey(soundName))
        {
            AudioSource tempSource = gameObject.AddComponent<AudioSource>();
            tempSource.clip = soundDictionary[soundName];
            tempSource.Play();

            Destroy(tempSource, tempSource.clip.length);
        }
        else
        {
            Debug.LogWarning($"Sound {soundName} not found!");
        }
    }

}

