using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SongList : MonoBehaviour
{
    public Animator Thisani;

    public float sizeP;
    public Image asdf;
    public Image title_;
    /// <summary>
    /// 곡 리스트
    /// </summary>
    public List<Image> SList;

    public bool StopSel;
    /// <summary>
    /// 배치 값
    /// </summary>
    /// 
    [HideInInspector]
    public float interval;
    [HideInInspector]
    public float Ypos;
    [HideInInspector]
    public float Height;

    //[HideInInspector]
    public Image SelThm;
    [HideInInspector]
    public bool SelThmIsble;
    //[HideInInspector]
    public Image NextSelThm;
    [HideInInspector]
    public bool NextSelIsble;

    public Image Currentsong; // 선택 된 곡 테두리 표시 
    float TIMER;//타이머 -> 곡 선택 후 변경 금지 시간

    public GameObject StageBut;//선택 버튼
    [HideInInspector]
    public bool ButON;// 상태

    public Image Inf_Img;
    public Image qwerqwer;
    public bool Thm_infisBle;

    public bool infMod;
    // Use this for initialization
    void Start()
    {



        StopSel = false;
        SelThmIsble = false;
        NextSelIsble = false;
        ButON = true;
        Thm_infisBle = false;
        infMod = false;
        for (int i = 0; i < SList.Count; i++)
        {
            SList[i].gameObject.transform.localPosition = new Vector3((i * (interval + Height)), Ypos, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StopSel == false)
        {
            SelThmEft();
        }
        //  sadf();
    }

    public void SelStage(Button but)//버튼 
    {
        if (StopSel == false)
        {

            if (SelThm != null)
            {
                NextSelThm = SelThm;
                NextSelThm.transform.GetChild(0).gameObject.SetActive(false);
            }
            SelThm = but.image;



            SelThmIsble = true;

            //NextSelThm
        }
    }

    void SelThmEft()//곡선택 
    {
        if (SelThm != null)
        {

            if (SelThmIsble == true && NextSelIsble == false)
            {
                if (ButON)
                {
                    ButON_Fun();
                    ButON = false;
                }

                SelThmIsble = false;

                NextSelIsble = true;
                if (SelThm != NextSelThm)
                {
                    Currentsong.rectTransform.localPosition = new Vector3(SelThm.rectTransform.localPosition.x, SelThm.rectTransform.localPosition.y + 100, 0);
                    iTween.Stop(Currentsong.gameObject);
                    Eft();

                    NowSongedge();

                }
                else
                {
                    Singleton.Instance._SongNum = SelThm.GetComponent<ThmList>().SongNum;
                    Debug.Log(Singleton.Instance._SongNum);
                    THmInf();
                    Infsize();
                    StopSel = true;

                }
            }
            if (NextSelIsble == true)
            {
                if (NextSelThm != null)
                {
                    if (SelThm != NextSelThm)
                    {
                        OutEft();
                    }
                    NextSelIsble = false;
                }
            }



        }
    }
































    /// <summary>
    /// 
    /// </summary> 
    /// 
    void Eft()
    {
        iTween.ValueTo(this.gameObject, iTween.Hash(
            "from", 0,
            "to", 50,
            "time", 0.2f,
            "onUpdate", "EftVal"
            ));

        SelThm.transform.GetChild(0).gameObject.SetActive(true);

    }
    void EftVal(float Val)
    {
        SelThm.rectTransform.sizeDelta = new Vector2(550 + Val + sizeP, 550 + Val + sizeP);
    }



    void OutEft()
    {
        iTween.ValueTo(this.gameObject, iTween.Hash(
          "from", 0,
          "to", 50,
          "time", 0.2f,
          "onUpdate", "OutEftVal"
           ));
    }
    void OutEftVal(float Val)
    {
        NextSelThm.rectTransform.sizeDelta = new Vector2((550 + 50) - Val + sizeP, (550 + 50) - Val + sizeP);
    }

    void NowSongedge()
    {
        // Debug.Log(SelThm.name);

        iTween.MoveTo(Currentsong.gameObject, iTween.Hash(
            "x", SelThm.rectTransform.position.x,
            "y", SelThm.rectTransform.position.y,
            "time", 0.5f,
            "easetype", iTween.EaseType.easeOutQuint
            ));
    }

    void ButON_Fun()
    {
        iTween.MoveBy(StageBut, iTween.Hash(
            "x", -475,
            "time", 1.5f));

    }





    void THmInf()
    {
        Thisani.SetBool("ch", true);
        Inf_Img.gameObject.SetActive(true);
        //iTween.ValueTo(this.gameObject, iTween.Hash(
        //    "from", 1,
        //    "to", 1,
        //    "time", 1f,
        //    "onUpdate", "asdftgh",
        //    "oncomplete", "Inf_Val"));
    }

    void asdftgh(float Val)
    {
  //      asdf.material.SetFloat("_Radius", Val);
    }

    void Infsize()
    {

        Thisani.SetBool("ch", true);
        //Inf_Img.gameObject.SetActive(true);
        iTween.ValueTo(this.gameObject, iTween.Hash(
            "from", 0,
            "to", 1,
            "time", 0.2f,
            "delay", 0.5f,
            "onUpdate", "Yinf"
            ));
    }

    void Inf_Val()
    {

        infMod = true;
    }
    void Yinf(float val)
    {
        title_.color = new Vector4(255, 255, 255, val);
        for (int i = 1; i <= 3; i++)
        {
            title_.transform.GetChild(i).GetComponent<Image>().color = new Vector4(255, 255, 255, val);
        }
        qwerqwer.color = new Vector4(255, 255, 255, val);
        for(int i = 0; i<=3; i++)
        {
            qwerqwer.transform.GetChild(i).GetComponent<Image>().color = new Vector4(255, 255, 255, val);
        }
    }


}