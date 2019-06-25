using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongCtrl : MonoBehaviour
{
    AudioSource StageAudio;

    public float timer_;
    bool chek1;
    bool chek2;
    private void Start()
    {
        chek1 = true;
        chek2 = false;
        StageAudio = GetComponent<AudioSource>();
    }


    private void Update()
    {
        timer_ += Time.deltaTime;
        if (timer_ > 15.5f && chek1 == true)
        {
            StartCoroutine("SoundChang");
            chek1 = false;
            chek2 = true;
        }
        if (timer_ > 20f && chek2 == true)
        {
            StartCoroutine("SoungVolueUp");
            chek1 = true;
            chek2 = false;
            timer_ = 0;
        }
    }

    public void StopC()
    {
        StopAllCoroutines();
    }

    IEnumerator SoundChang()
    {
        while (true)
        {
            StageAudio.volume -= 0.15f;
            yield return new WaitForSeconds(0.5f);
            if (StageAudio.volume <= 0)
            {
                StageAudio.Play();
                break;
            }
        }
    }
    IEnumerator SoungVolueUp()
    {
        while (true)
        {
            StageAudio.volume += 0.15f;
            yield return new WaitForSeconds(0.5f);
             if(StageAudio.volume >=1)
            {
                break;
            }
        }
    }

}
