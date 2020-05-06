using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{   [HideInInspector]
    public  AudioMixer audioMixer;
    public sound[] sounds;
    public static AudioManager instance;
    

    // Start is called before the first frame update
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

        foreach(sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitchs;
            s.source.loop = s.loop;
            AudioMixerGroup[] audioMixGroup = audioMixer.FindMatchingGroups("Master");
            s.source.outputAudioMixerGroup = audioMixGroup[0];
        } 
    }

    public void play(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            return;
        }
        s.source.Play();
    }

    private void Start()
    {
        play("theme");
    }

    public void optionMenuVolume(float volume)
    {
        audioMixer.SetFloat("bgm", volume); 
    }
}
