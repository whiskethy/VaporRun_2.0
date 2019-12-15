using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicVolumeSlider;
    public Slider soundFXVolumeSlider;
    public Toggle retroToggle;
    public Toggle tutorialToggle;
    private int retroOn;
    private int tutorialOn;

    private float volume;

    private void Start() {
        volume =  PlayerPrefs.GetFloat("MusicVolume");
        musicVolumeSlider.value =  volume;
        audioMixer.SetFloat("Music", volume);
        
        volume =  PlayerPrefs.GetFloat("SoundEffectsVolume");
        soundFXVolumeSlider.value =  volume;
        audioMixer.SetFloat("SoundEffects", volume);

        tutorialOn = PlayerPrefs.GetInt("ShowTutorial"); //1 = true

        if(tutorialOn == 0)
        {
            tutorialToggle.isOn = false;
        }
        if(tutorialOn == 1)
        {
           tutorialToggle.isOn = true;
        }
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void SetSoundEffectsVolume(float volume)
    {
        audioMixer.SetFloat("SoundEffects", volume);
        PlayerPrefs.SetFloat("SoundEffectsVolume", volume);
    }

    public void TutorialToggle(bool effectStatus)
    {
        if(effectStatus == true)
        {
            PlayerPrefs.SetInt("ShowTutorial", 1); //1 = true
        }
        if(effectStatus == false)
        {
            PlayerPrefs.SetInt("ShowTutorial", 0);
        }
        
    }
}
