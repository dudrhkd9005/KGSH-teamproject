using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;
    private AudioSource backgroundAudio;
    private AudioSource effectAudio;

    private Dictionary<string, AudioClip> effectSounds;
    private Dictionary<string, AudioClip> musicSounds;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<SoundManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        effectSounds = new Dictionary<string, AudioClip>();
        musicSounds = new Dictionary<string, AudioClip>();
        object[] effect= Resources.LoadAll<AudioClip>("Effect Sound");//Assets/Effect Sound폴더에 있는 브금 다 가져옴
        object[] music = Resources.LoadAll<AudioClip>("Music");//위랑 같음
        for (int i = 0; i < effect.Length; i++)
        {
            effectSounds[(effect[i] as AudioClip).name] = effect[i] as AudioClip;
        }
        for (int i = 0; i < music.Length; i++)
        {
            musicSounds[(music[i] as AudioClip).name] = music[i] as AudioClip;

        }
        backgroundAudio=gameObject.AddComponent<AudioSource>();
        effectAudio = gameObject.AddComponent<AudioSource>();
        PlayBackgroundSound("bgm2");
    }
    public void PlayBackgroundSound(string name)
    {
        backgroundAudio.clip = musicSounds[name];
        backgroundAudio.Play();
    }
    public void PlayEffectSound(string name)
    {
        effectAudio.PlayOneShot(effectSounds[name]);
    }
}