using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound snd in sounds)
        {
            snd.source = gameObject.AddComponent<AudioSource>();
            snd.source.clip = snd.audioClip;
            snd.source.volume = snd.volume;
            snd.source.pitch = snd.pitch;
            snd.source.loop = snd.loop;
        }
    }

    void Start()
    {
        PlaySound("Icky Thump");
    }

    public void PlaySound(string soundName)
    {
        Sound snd = Array.Find(sounds, sound => sound.name == soundName);
        if (snd == null)
        {
            Debug.LogWarning("Sound: " + soundName +" not found!");
            return;
        }
        snd.source.Play();
    }
}
