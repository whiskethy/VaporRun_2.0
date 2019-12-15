using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public AudioMixerGroup audioMixer;
    [Range(0f, 1f)]public float volume = 0.7f;
    [Range(0.5f, 1.5f)]public float pitch = 1f;
    private AudioSource source;

    public void SetSource(AudioSource inSource)
    {
        source = inSource;
        source.clip = clip;
    }
    public void SetMixer(AudioMixerGroup inMixer)
    {
        audioMixer = inMixer;
        source.outputAudioMixerGroup = inMixer;
    }

    public void Play()
    {
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }
    public void AdjustVolume(float inVolume)
    {
        source.volume = inVolume;
    }
     public void AdjustPitch(float inPitch)
    {
        source.pitch = inPitch;
    }
    public float GetPitch()
    {
        return source.pitch;
    }
    public float GetVolume()
    {
        return source.volume;
    }
}

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public AudioMixerGroup audioMixer;
    [SerializeField] Sound[] sounds;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one audio manager in scene");
        }
        else{

            instance = this;    
            
        }
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject temp = new GameObject("Sound_" + i +"_"+sounds[i].name); //create objects for each sound
            temp.transform.SetParent(this.transform);
            sounds[i].SetSource(temp.AddComponent<AudioSource>()); //give each sound it's own source
            sounds[i].SetMixer(audioMixer); //give each sound it's own source
        }
    }

    public void PlaySound(string inName)
    {
        GetSound(inName).Play();
    }

    public void AdjustSoundVolume(string inName, float inVolume)
    {
        GetSound(inName).AdjustVolume(inVolume);
    }

    public void AdjustSoundPitch(string inName, float inPitch)
    {
        GetSound(inName).AdjustPitch(inPitch);
    }
    public float GetSoundPitch(string inName)
    {
        return GetSound(inName).GetPitch();
    }
    public Sound GetSound(string inName)
    {
        for (int i = 0; i < sounds.Length; i++) //inefficient, but does the job for only a few sounds
        {
            if(sounds[i].name == inName)
            {
                return sounds[i];
            }
        }
        return null;
    }

}
