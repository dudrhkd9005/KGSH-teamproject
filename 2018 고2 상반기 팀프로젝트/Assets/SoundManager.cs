using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource bgm;
    public AudioSource effect;
    

    public void PlayEffect(AudioClip audioClip)
    {
        effect.PlayOneShot(audioClip);
    }

    public void PlayBgm(AudioClip audioClip)
    {
        bgm.Stop();
        bgm.clip = audioClip;
        bgm.Play();
    }
}
