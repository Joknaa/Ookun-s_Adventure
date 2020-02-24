using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (CurrentScene == "TheWorld") {  MainTheme = "TownTheme";  
        } 
        else if (CurrentScene == "Dungeon")  { MainTheme = "DungeonTheme"; }
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
