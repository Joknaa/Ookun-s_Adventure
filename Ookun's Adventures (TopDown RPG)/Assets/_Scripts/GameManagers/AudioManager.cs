using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [HideInInspector] public String MainTheme;


    public Sound[] Sounds;


    void Awake()
    {
        String CurrentScene = SceneManager.GetActiveScene().name;

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
        String CurrentScene = SceneManager.GetActiveScene().name;

        switch (CurrentScene)
        {
            case "TheWorld":
                MainTheme = "TownTheme";
                break;
            case "Dungeon":
                MainTheme = "DungeonTheme";
                break;
            case "HouseInteriour":
                MainTheme = "HouseInteriourTheme";
                break;
            default: 
                break;
        }

        PlaySound(MainTheme);
    }


    public void PlaySound(string SoundName)
    {
        Sound ThisSound = Array.Find(Sounds,sound => sound.Name == SoundName);
        ThisSound.AudioSource.Play();
    }

    public void ChangeSoundVolume()
    {
    }


}
