using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapScrolling : MonoBehaviour
{
    [Range(1, 50)]
    [Header("Controllers")]
    public int panCount;
    [Range(0, 500)]
    public int PanOffset;
    [Range(0f, 20f)]
    public float snapSpeed;
    [Range(0f, 5f)]
    public float scaleOffset;
    [Range(0f, 20f)]
    public float ScaleSpeed;
    [Header("Other Object")]
    public GameObject PanPrefab;

    public ScrollRect scrollRect;

    private GameObject[] instPans;
    private Vector2[] panPos;
    private Vector2[] panScale;

    private RectTransform contentRect;
    private Vector2 contentVector;

    /// <summary>
    /// Inf
    /// </summary>
    public Animator InfAnim;
    public AudioSource _Audio;
    public SongBuffer SongInf;
    public SongCtrl songctrl_;
    private bool SongValue;
    public GameObject InfUI;
    public SimpleSpectrum spectrum_;
    //public Image bestranking;
    public UImng uictrl;

    public Sprite[] ranks;

    public bool StartSelSOng;
    //public Text maxsc;
    //public Text noteAmt;
    //public Text _time;

    //public SoundManager soundManager;
    //public AudioClip tick;

    public Button playbut;
    bool _Play;

    public SpriteNumber bestScore;
    ////////////////////////////////

    private int selectedPanId;
    private bool isScrolling;

    bool moveR;

    private void Awake()
    {
        SongValue = false;
        _Play = false;
        StartSelSOng = false;
        SongInf.songInf[Singleton.Instance._SongNum].MaxScore = Singleton.Instance.maxssc[Singleton.Instance._SongNum];
        if (Singleton.Instance.chekRank[Singleton.Instance._SongNum] != 5)
        {
            SongInf.songInf[Singleton.Instance._SongNum].Rank_ = ranks[Singleton.Instance.chekRank[Singleton.Instance._SongNum]];
        }
        contentRect = GetComponent<RectTransform>();
        instPans = new GameObject[panCount];
        panPos = new Vector2[panCount];
        panScale = new Vector2[panCount];
        for (int i = 0; i < panCount; i++)//////////////////////////////////////////////위치를 뿌림
        {
            instPans[i] = Instantiate(PanPrefab, transform, false);
            //Debug.Log(instPans[i].GetComponent<RectTransform>().rect.width);
            if (i == 0) continue;
            instPans[i].transform.localPosition = new Vector2(instPans[i - 1].transform.localPosition.x + PanPrefab.GetComponent<RectTransform>().sizeDelta.x + PanOffset,
                                                              instPans[i].transform.localPosition.y);
            panPos[i] = -instPans[i].transform.localPosition;
            instPans[i].transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 0);
        }
        
       
    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        //Debug.Log(transform.localPosition);
        for (int i = 0; i < panCount; i++)
        {
            instPans[i].GetComponent<Image>().type = Image.Type.Simple;
            instPans[i].GetComponent<Image>().SetNativeSize();
        }
        //  Debug.Log(Singleton.Instance.SongNum);

        float nearestPos = float.MaxValue;
        for (int i = 0; i < panCount; i++)
        {
            float distance = Mathf.Abs(contentRect.anchoredPosition.x - panPos[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                selectedPanId = i;//현재 중앙에 있는 오브젝트
     
            }
            //선택되어 있는 오브젝트 크기//
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            float scale = Mathf.Clamp(1 / (distance / PanOffset) * scaleOffset, 0.5f, 1f);
            panScale[i].x = Mathf.SmoothStep(instPans[i].transform.localScale.x, scale, ScaleSpeed * Time.fixedDeltaTime);
            panScale[i].y = Mathf.SmoothStep(instPans[i].transform.localScale.y, scale, ScaleSpeed * Time.fixedDeltaTime);
            instPans[i].transform.localScale = panScale[i];
            if (_Play)
            {
                Color temp = new Color(1, 1, 1, Mathf.SmoothStep(instPans[i].transform.GetChild(0).GetComponent<Image>().color.a, Mathf.Clamp(1 / distance * scaleOffset, 0, 1f), ScaleSpeed * Time.fixedDeltaTime));
                instPans[i].transform.GetChild(0).GetComponent<Image>().color = temp;
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
        float scrollVelocity = Mathf.Abs(scrollRect.velocity.x);
        if (scrollVelocity < 400 && !isScrolling) scrollRect.inertia = false;
        if (isScrolling || scrollVelocity > 400) return;
        contentVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, panPos[selectedPanId].x, snapSpeed * Time.deltaTime);
        contentRect.anchoredPosition = contentVector;
    }

    /// <summary>
    /// --------------------------------------------------------------------------
    /// </summary>
    private void Update()
    {
        bestScore.value = GameManager.Instance.GetBestScore(selectedPanId);
        //Debug.Log(selectedPanId);
        if (StartSelSOng == true)
        {
            InfUI.transform.GetChild(0).GetComponent<Image>().sprite = SongInf.songInf[selectedPanId].SongDif;
            InfUI.transform.GetChild(1).GetComponent<Image>().sprite = SongInf.songInf[selectedPanId].SongName;
            InfUI.transform.GetChild(1).GetComponent<Image>().SetNativeSize();
            InfUI.transform.GetChild(0).GetComponent<Image>().SetNativeSize();
            //if (SongInf.songInf[selectedPanId].MaxScore == 0)
            //{
            //    maxsc.text = "000000";
            //}
            //else
            //{
            //    maxsc.text = "" + SongInf.songInf[selectedPanId].MaxScore;
            //}

            // if (Singleton.Instance.chekRank[selectedPanId] == 5)              
            //{
            //    bestranking.gameObject.SetActive(false);
            //}
            //else
            //{
            //    bestranking.gameObject.SetActive(true);
            //    bestranking.sprite = ranks[Singleton.Instance.chekRank[selectedPanId]];
            //}
            //noteAmt.text = "" + SongInf.songInf[selectedPanId].Noteamount;
            //_time.text = "" + SongInf.songInf[selectedPanId].SongTime;
            iTween.ValueTo(this.gameObject, iTween.Hash(
                "time", 1.0f,
                "from", 0,
                "to", 1,
                "onUpdate", "qwer",
                "oncomplete", "asdf"));
            StartSelSOng = false;

            for (int i = 0; i < panCount; i++)
            {
                instPans[i].transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 0);
            }
        }

        if (_Play == true)
        {
            F_SongInfMng();
        }
        
  
    }
    void asdf()
    {
        _Play = true;
    }
    void qwer(float val)
    {
        for (int i = 0; i < panCount; i++)
        {
            instPans[i].GetComponent<Image>().color = new Vector4(255, 255, 255, val);
            if(i==0)
            instPans[i].transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, val);
        }
    }

    void F_SongInfMng()
    {


        if (scrollRect.inertia == false)
        {
            GameManager.Instance.playMusicNum = selectedPanId;
            InfAnim.SetBool("InfFaid", true);
          

            if (!SongValue)
            {
                if (uictrl.SpeChekj == true)
                {
                    spectrum_.isEnabled = true;
                }

                if (SongInf.songInf[selectedPanId].Name == "qwer")
                {
                    playbut.gameObject.SetActive(false);
                }
                else
                {
                    playbut.gameObject.SetActive(true);
                }// StartCoroutine("SongStart");
                _Audio.GetComponent<AudioSource>().clip = SongInf.songInf[selectedPanId]._audio;
                _Audio.Play();
                SongInfChang();
                songctrl_.timer_ = 0;
                songctrl_.StopC();
                _Audio.volume = 1;
                iTween.ValueTo(this.gameObject, iTween.Hash(
                    "from", _Audio.volume,
                    "to", 1,
                    "time", 1.0f,
                    "onupdate", "VolumeCtrl"));
                SongValue = true;
            }


        }
        else            //스크롤링 하는중
        {
            InfAnim.SetBool("InfFaid", false);
       //     spectrum_.isEnabled = false;
            if (SongValue == true)
            {
                if (uictrl.SpeChekj == true)
                {
                    spectrum_.isEnabled = false;
                }
            //    spectrum_.isEnabled = false;
                songctrl_.timer_ = 0;
                songctrl_.StopC();
                iTween.Stop();
                iTween.ValueTo(this.gameObject, iTween.Hash(
                    "from", _Audio.volume,
                    "to", 0,
                    "time", 1.0f,
                    "onupdate", "VolumeCtrl_"));
                SongValue = false;
            }
        }
    }

    void SongInfChang()
    {
        //soundManager.PlayEffect(tick);
        InfUI.transform.GetChild(0).GetComponent<Image>().sprite = SongInf.songInf[selectedPanId].SongDif;
        InfUI.transform.GetChild(1).GetComponent<Image>().sprite = SongInf.songInf[selectedPanId].SongName;
        //noteAmt.text = "" + SongInf.songInf[selectedPanId].Noteamount;
        //_time.text = "" + SongInf.songInf[selectedPanId].SongTime;
        //if (Singleton.Instance.maxssc[Singleton.Instance._SongNum] == 0)
        //{
        //    maxsc.text = "000000";
        //}
        //else
        //{
        //    maxsc.text = "" + Singleton.Instance.maxssc[Singleton.Instance._SongNum];
        //}

        //Debug.Log(Singleton.Instance.chekRank[Singleton.Instance._SongNum]);
        //if (Singleton.Instance.chekRank[Singleton.Instance._SongNum] == 5)
        //{
        //    bestranking.gameObject.SetActive(false);
        //}
        //else
        //{
        //    bestranking.gameObject.SetActive(true);
        //    bestranking.sprite = ranks[Singleton.Instance.chekRank[Singleton.Instance._SongNum]];
        //}
        InfUI.transform.GetChild(1).GetComponent<Image>().SetNativeSize();
        InfUI.transform.GetChild(0).GetComponent<Image>().SetNativeSize();
    }

    public void Scrolling(bool scroll)//스크롤링 체크 
    {
        isScrolling = scroll; //터치를 땠을때 false가 댐
        if (scroll) scrollRect.inertia = true;
    }

    public void ClickMoveL(float val)//->
    {
        if (scrollRect.inertia == false && selectedPanId != 0)
        {
            Vector3 pos = transform.position;
            pos.x += val;
            transform.position = pos;

            scrollRect.inertia = true;
        }
        if (scrollRect.inertia == false && selectedPanId == 0)
        {
            Vector3 pos = transform.position;
            // pos.x += 4;
            // transform.position = pos;
            pos.x += val;
            transform.position = pos;

            scrollRect.inertia = true;
        }
    }
    public void ClickMoveR(float val)
    {
        if (scrollRect.inertia == false && selectedPanId != 0)
        {
            var pos = transform.position;
            pos.x += val;
            transform.position = pos;

            scrollRect.inertia = true;
        }
    }

    public void MoveR()
    {
        //Vector3 pos = transform.localPosition;
        //pos.x += -400f;
        //if(selectedPanId == 0)
        //{
        //    pos.x += -1000f;
        //}
        if (scrollRect.inertia == false && selectedPanId != panCount - 1)
        {
            //transform.localPosition = pos;
            transform.localPosition += new Vector3(-400, 0);
            scrollRect.inertia = true;
        }
        //Debug.Log("pos : " + pos.x);
    }

    public void MoveL()
    {
        //Vector3 pos = transform.localPosition;
        //pos.x += -400f;
        //if(selectedPanId == 0)
        //{
        //    pos.x += -1000f;
        //}
        if (scrollRect.inertia == false && selectedPanId != 0)
        {
            //transform.localPosition = pos;
            transform.localPosition += new Vector3(400, 0);
            scrollRect.inertia = true;
        }
        //Debug.Log("pos : " + pos.x);
    }

    void VolumeCtrl(float val)
    {
        _Audio.volume = val;
    }
    void VolumeCtrl_(float val)
    {
        _Audio.volume = val;
    }

}
