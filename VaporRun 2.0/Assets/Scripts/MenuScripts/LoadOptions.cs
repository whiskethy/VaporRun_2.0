using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LoadOptions : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Awake()
    {
        //GetRetroOption();
        //GetAudioOption();
    }



    void GetAudioOption()
    {
        if(PlayerPrefs.HasKey("MasterVolume"))
        {
            float temp = PlayerPrefs.GetFloat("MasterVolume");
            audioMixer.SetFloat("MasterVolume", temp);
        }
        if(PlayerPrefs.HasKey("MusicVolume"))
        {
            float temp = PlayerPrefs.GetFloat("MusicVolume");
            audioMixer.SetFloat("Music", temp);
        }
        if(PlayerPrefs.HasKey("SoundEffectsVolume"))
        {
            float temp = PlayerPrefs.GetFloat("SoundEffectsVolume");
            audioMixer.SetFloat("SoundEffects", temp);
        }
    }
}
