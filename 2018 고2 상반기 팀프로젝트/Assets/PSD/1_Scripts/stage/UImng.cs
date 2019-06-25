using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImng : MonoBehaviour
{
    public Animator anim1;
    bool Chak;

    public Button but1;
    public Button but2;
    public Button but3;
    public SimpleSpectrum THmspe;
    public bool SpeChekj;


  //  public int count;
    public int TotalScore;
    public int bestComnb;
    public int[] bestScore;
    public string[] Composer;
    public int PlayCount;
    public int[] Num_count;

    public Text _count;
    public Text _totle;
    public Text _BestCombe;


    public Text com;
    public Text no;
    public Text time_;
    public Text bestSocreText;
    public Text count;
    public Image Dif;
    public Text Name_;

    public SongBuffer songinf;

    public Text singval;

    public Slider singkval;


    public void sigkF()
    {
        if(singkval.value == 0 )
        {
            singval.text = "Default";
        }
        else
        {
            singval.text = "" + singkval.value;
        }
    }
    public void _but1()
    {
        singkval.value--;
    }
    public void _but2()
    {
        singkval.value++;
    }

    private void Start()
    {
        Num_count = new int[8] { 0, 0, 0, 0, 0, 0, 0,0 };
        SpeChekj = false;
        Chak = false;
        bestComnb = 0;
        Dif.gameObject.SetActive(false);
        Name_.gameObject.SetActive(false);
    }
    public void _Click()
    {
        if (Chak == false)
        {
            anim1.SetBool("Click", true);
            Chak = true;
        }
        else
        {
            anim1.SetBool("Click", false);
            Chak = false;
        }
    }

    public void BGMSoundVolme(Slider sli)
    {
        Singleton.Instance.BGN_Volume = sli.value;
    }
    public void SFXSoundVolme(Slider sli)
    {
        Singleton.Instance.SFX_Volume = sli.value;
    }

    public void ClickCk()
    {
        but1.interactable = true;
        but2.interactable = true;
        but3.interactable = true;
    }

    public void SpeOnf()
    {
        if (SpeChekj == true)
        {
            THmspe.isEnabled = false;
            SpeChekj = false;
        }
        else
        {
            THmspe.isEnabled = true ;
            SpeChekj = true;
        }
    }

    public void Windowchek(GameObject obj)
    {
        if (obj.activeSelf == true)
        {
            obj.SetActive(false);
        }
        else
        {
            obj.SetActive(true);
        }
                }

    public void StartGame()
    {
        Singleton.Instance.play_Count++;
       Singleton.Instance.Num_count[Singleton.Instance._SongNum]++;
    }

    public void OnProfil()
    {
        TotalScore = Singleton.Instance.maxssc[0] + Singleton.Instance.maxssc[1] + Singleton.Instance.maxssc[3] + Singleton.Instance.maxssc[4] + Singleton.Instance.maxssc[5] + Singleton.Instance.maxssc[6] + Singleton.Instance.maxssc[7] + Singleton.Instance.maxssc[2];
        _count.text = "" + Singleton.Instance.play_Count;
        _totle.text = "" + TotalScore;
        _BestCombe.text = "" + Singleton.Instance._BestCombe;

    }

    public void SongInf(int num)
    {
        Dif.gameObject.SetActive(true);
        Name_.gameObject.SetActive(true);
        com.text = songinf.songInf[num].Composer;
        no.text = ""+songinf.songInf[num].Noteamount;
        time_.text = "" + songinf.songInf[num].SongTime;
        bestSocreText.text = "" + songinf.songInf[num].MaxScore;
        count.text = "" + Singleton.Instance.Num_count[num];

        Dif.sprite = songinf.songInf[num].SongDif;
        Dif.SetNativeSize();
        Name_.text = songinf.songInf[num].SongName_;


    }
    public void GameOut()
    {
        Application.Quit();
    }
}
