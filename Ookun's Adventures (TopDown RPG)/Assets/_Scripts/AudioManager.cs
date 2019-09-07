using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    void Awake()
    {
        foreach (Sound ThisSound in Sounds)
        {
            ThisSound.AudioSource = gameObject.AddComponent<AudioSource>();
            ThisSound.AudioSource.clip = ThisSound.Clip;
            ThisSound.AudioSource.volume = ThisSound.Volume;
            ThisSound.AudioSource.pitch = ThisSound.Pitch;
        }
    }


    private void Start()
    {
        PlaySound("TownTheme");
    }


    public void PlaySound(string SoundName)
    {
        Sound ThisSound = Array.Find(Sounds,sound => sound.Name == SoundName);
        ThisSound.AudioSource.Play();
    }


}
