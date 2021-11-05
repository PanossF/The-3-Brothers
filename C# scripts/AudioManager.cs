using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //public Sound[] sounds;

    //public static AudioManager instance;
    // Start is called before the first frame update
    void Start()
    {
        //Play("BGMusic");
    }

    void Awake()
    {
        /*if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string name)
    {
        /*Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();*/
    }

    public void Stop(string name)
    {
        /*Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();*/
    }

    /*[System.Serializable]
    public class Sound
    {
        [HideInInspector]
        public AudioSource source;

        public string name;

        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;
        [Range(.1f, 3f)]
        public float pitch;
    }*/
}
