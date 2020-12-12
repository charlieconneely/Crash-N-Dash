using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    void Awake() {

        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        /* add components to each sound */
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start() {        
        Play("Theme");
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }
        s.source.Play();
    }

    public void AdjustVolume(float volume, string name) {
        if (name=="Theme") {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.volume = volume;
            return;
        } 
        /* Adjust all sounds besides music */
        foreach (Sound s in sounds) {
            if (s.name != "Theme") {
                s.source.volume = volume;
            }
        }
    }

    public float GetVolume(string name) {
        /* If name != theme - adjust all sounds */
        if (name != "Theme") {
            foreach (Sound sound in sounds) {
                return sound.source.volume;
            }
        }
        /* Adjust music only */
        Sound s = Array.Find(sounds, sound => sound.name == name);
        return s.source.volume;
    }
}
