using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultScripts : MonoBehaviour
{

    public bool EftOn;

    public int scroe;
    public int Pe;
    public int good;
    public int bad;
    public int miss;
    public int combo;


    public GameObject Line;
    public GameObject _Title;
    public GameObject _Thm;
    public Image lang;

    public GameObject _score;
    public GameObject _Combo;
    public GameObject Judgment;
    public GameObject But_;


    public Sprite[] title;
    public Sprite[] thm;
    public Sprite[] Rank;

    public int maxpoint;
    public Sprite Maxranl;
    // Use this for initialization
    void Start()
    {
        _Title.transform.GetChild(1).GetComponent<Image>().sprite = title[Singleton.Instance._SongNum];
        _Thm.transform.GetChild(1).GetComponent<Image>().sprite = thm[Singleton.Instance._SongNum];
        _Title.transform.GetChild(1).GetComponent<Image>().SetNativeSize();
    }

    // Update is called once per frame
    void Update()
    {
        if (EftOn == true)
        {
            _Title.transform.parent.gameObject.SetActive(true);
            //ResultVal();
            resultEFt();
            EftOn = false;
        }
    }

    public void ResultVal(int sc, int com, int pe_, int good_, int bad_, int miss_, int rank)
    {
        scroe = sc;
        combo = com;
        Pe = pe_;
        good = good_;
        bad = bad_;
        miss = miss_;

        if(Singleton.Instance._BestCombe < com)
        {
            Singleton.Instance._BestCombe = com;
        }

        if(Singleton.Instance._SongBestCombe[Singleton.Instance._SongNum] < com  )
        {
            Singleton.Instance._SongBestCombe[Singleton.Instance._SongNum] = com;
        }
        
        if (rank == 0)
        {
            lang.sprite = Rank[0];
            Singleton.Instance.chekRank[Singleton.Instance._SongNum] = rank;
        }
        else if (rank == 1)
        {
            lang.sprite = Rank[1];
            Singleton.Instance.chekRank[Singleton.Instance._SongNum] = rank;
        }
        else if (rank == 2)
        {
            lang.sprite = Rank[2];
            Singleton.Instance.chekRank[Singleton.Instance._SongNum] = rank;
        }
        else
        {
            lang.sprite = Rank[3];
            Singleton.Instance.chekRank[Singleton.Instance._SongNum] = rank;
        }

        if(Singleton.Instance.maxssc[Singleton.Instance._SongNum]< sc)
        {
            Singleton.Instance.maxssc[Singleton.Instance._SongNum] = sc;
        }

        if (Singleton.Instance.chekRank[Singleton.Instance._SongNum] < rank)
        {
            Singleton.Instance.chekRank[Singleton.Instance._SongNum] = rank;
            Singleton.Instance.bestrank[Singleton.Instance._SongNum] = Rank[rank];
        }
    }

    void resultEFt()
    {
        //iTween.ValueTo(this.gameObject, iTween.Hash(
        //    "from", 0,
        //    "to", 1,
        //    "time", 0.5f,
        //    "onUpdate", "title1"));
        iTween.ValueTo(this.gameObject, iTween.Hash(
           "from", 0,
           "to", 1,
           "time", 0.5f,
           "delay", 0.5f,
           "onUpdate", "title2"));
        //iTween.ValueTo
        iTween.MoveBy(_Title.transform.GetChild(0).gameObject, iTween.Hash(
            "x", 0,
            "y", -400,
            "time", 1.0f
            ));
        ///////////////////////////////////////////////////////////////////

        iTween.ValueTo(this.gameObject, iTween.Hash(
            "from", 0,
            "to", 1,
            "time", 0.8f,
            "delay", 0.6f,
            "onUpdate", "LineEFt"));

        ///////////////////////////////////////////////////////////////////////

        iTween.ValueTo(this.gameObject, iTween.Hash(
            "from", 0,
            "to", 1,
            "time", 0.7f,
            "delay", 1.4f,
            "onUpdate", "ThmEft"));

        /////////////////////////////////////////////////////////////////////////////////////

        iTween.ValueTo(this.gameObject, iTween.Hash(
            "from", 0,
            "to", 1,
            "onUpdate", "Rang",
            "time", 1f,
            "delay", 2.2f));
        iTween.ValueTo(this.gameObject, iTween.Hash(
           "from", lang.rectTransform.sizeDelta.x,
            "to", 560,
            "time", 1.3,
            "delay", 2.2f,
            "onUpdate", "RangSize",
            "easetype", iTween.EaseType.easeInOutBack));
        iTween.ValueTo(this.gameObject, iTween.Hash(
            "from", 1,
            "to", 0.5,
            "time", 0.7f,
            "delay", 2.2f,
            "onUpdate", "ThmR"));

        ///////////////////////////////////////////////////////

        iTween.ValueTo(this.gameObject, iTween.Hash(
            "from", 0,
            "to", 1,
            "time", 0.5f,
            "delay", 2.8f,
            "onUpdate", "Score_e"));

        iTween.ValueTo(this.gameObject, iTween.Hash(
            "from", 0,
            "to", Random.Range(9999, 99999),
            "time", 1.0f,
            "delay", 2.9f,
            "onUpdate", "ScoreF",
            "oncomplete", "score_"));
        /////////////////////////////////////////////////////////
        iTween.ValueTo(this.gameObject, iTween.Hash(
            "from", 0,
            "to", 1,
            "time", 0.7f,
            "delay", 2.8f,
            "Onupdate", "Combo_F"));

        iTween.ValueTo(this.gameObject, iTween.Hash(
           "from", 0,
           "to", Random.Range(9999, 99999),
           "time", 1.0f,
           "delay", 2.9f,
           "onUpdate", "COmbo_F",
           "oncomplete", "Combo_Val"));
        /////////////////////////////////////////////////////////////////////


        iTween.ValueTo(this.gameObject, iTween.Hash(
            "from", 0,
            "to", 1,
            "time", 0.8f,
            "delay", 3f,
            "onUpdate", "Judgment_f"));

        iTween.ValueTo(this.gameObject, iTween.Hash(
            "from", 0,
            "to", Pe,
            "time", 0.5f,
            "delay", 3.1f,
            "onUpdate", "pe_"

            ));
        iTween.ValueTo(this.gameObject, iTween.Hash(
 "from", 0,
 "to", good,
 "time", 0.5f,
 "delay", 3.1f,
 "onUpdate", "good_"

));
        iTween.ValueTo(this.gameObject, iTween.Hash(
 "from", 0,
 "to", bad,
 "time", 0.5f,
 "delay", 3.1f,
 "onUpdate", "bad_"


            ));
        iTween.ValueTo(this.gameObject, iTween.Hash(
 "from", 0,
 "to", miss,
 "time", 0.5f,
 "delay", 3.1f,
 "onUpdate", "Miss_"
 ));

        iTween.ValueTo(this.gameObject, iTween.Hash(
            "from", 0,
            "to", 1,
            "time", 0.5f,
            "delay", 3.6f,
            "onUpdate", "But_F"));
    }
    void title1(float val)
    {
        _Title.transform.GetChild(0).GetComponent<Image>().fillAmount = val;
        _Title.transform.GetChild(0).GetComponent<Image>().color = new Vector4(255, 255, 255, val);
    }
    void title2(float val)
    {
        _Title.transform.GetChild(1).GetComponent<Image>().fillAmount = val;
        _Title.transform.GetChild(1).GetComponent<Image>().color = new Vector4(255, 255, 255, val);
    }

    /////////////////////////////////////////////////
    void LineEFt(float val)
    {
        for (int i = 0; i <= 1; i++)
        {
            Line.transform.GetChild(i).GetComponent<Image>().fillAmount = val;
            Line.transform.GetChild(i).GetComponent<Image>().color = new Vector4(255, 255, 255, val);
        }
    }
    ///////////////////////////////////////////////////
    void ThmEft(float val)
    {
        for (int i = 0; i <= 2; i++)
        {
            _Thm.transform.GetChild(i).GetComponent<Image>().fillAmount = val;
            //  _Thm.transform.GetChild(i).GetComponent<Image>().color = new Vector4(_Thm.transform.GetChild(i).GetComponent<Image>().color.r, _Thm.transform.GetChild(i).GetComponent<Image>().color.g, _Thm.transform.GetChild(i).GetComponent<Image>().color.b, val);
        }
    }
    /////////////////////////////////////////////////////
    void Rang(float val)
    {
        lang.color = new Vector4(255, 255, 255, val);

    }
    void RangSize(float val)
    {
        lang.rectTransform.sizeDelta = new Vector2(val, val);
    }
    void ThmR(float val)
    {
        _Thm.transform.GetChild(1).GetComponent<Image>().color = new Vector4(_Thm.transform.GetChild(1).GetComponent<Image>().color.r, _Thm.transform.GetChild(1).GetComponent<Image>().color.g, _Thm.transform.GetChild(1).GetComponent<Image>().color.b, val);
    }
    /////////////////////////////////////////////////////////
    void Score_e(float val)
    {
        _score.transform.GetChild(0).GetComponent<Image>().color = new Vector4(255, 255, 255, val);
        _score.transform.GetChild(1).GetComponent<Text>().color = new Vector4(255, 255, 255, val);
    }

    void ScoreF(float val)
    {
        _score.transform.GetChild(1).GetComponent<Text>().text = "" + val;
    }
    void score_()
    {
        _score.transform.GetChild(1).GetComponent<Text>().text = "" + scroe;
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    void Combo_F(float val)
    {
        _Combo.transform.GetChild(0).GetComponent<Image>().color = new Vector4(255, 255, 255, val);
        _Combo.transform.GetChild(1).GetComponent<Text>().color = new Vector4(255, 255, 255, val);
    }

    void COmbo_F(float val)
    {
        _Combo.transform.GetChild(1).GetComponent<Text>().text = "" + val;
    }
    void Combo_Val()
    {
        _Combo.transform.GetChild(1).GetComponent<Text>().text = "" + combo;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Judgment_f(float val)
    {
        for (int i = 0; i <= 3; i++)
        {
            Judgment.transform.GetChild(i).GetComponent<Image>().color = new Vector4(255, 255, 255, val);
            Judgment.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().color = new Vector4(255, 255, 255, val);
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Miss_(float val)
    {
        Judgment.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "" + val;
    }
    void bad_(float val)
    {
        Judgment.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = "" + val;
    }
    void good_(float val)
    {
        Judgment.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = "" + val;
    }
    void pe_(float val)
    {
        Judgment.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "" + val;
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    void But_F(float val)
    {
        for (int i = 0; i <= 3; i++)
        {
            But_.transform.GetChild(i).GetComponent<Image>().color = new Vector4(255, 255, 255, val);
        }
    }
}
