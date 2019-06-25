using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spectrum : MonoBehaviour
{
    public int CreateSticKNum = 0;  //생성될 막대 갯수
    public float Interval = 0;      //생성될 막대 간격
   // public List<GameObject> Sticks; //막대 생성
    public List<Image> StickS_;
    public GameObject _Obj;         //막대 오브젝트
    public Image _obj;
    void Start()
    {
        for (int i = 0; i<CreateSticKNum; i++)
        {
            //GameObject obj = (GameObject)Instantiate(_Obj);
            //obj.transform.parent = GameObject.Find("Spectrum").transform;
            //obj.transform.localScale = Vector3.one;
            //obj.transform.localPosition = new Vector2(0 + Interval * i, 0);

            Image obj_ = (Image)Instantiate(_obj);
            obj_.rectTransform.parent = GameObject.Find("Spectrum").transform;
            obj_.rectTransform.localScale = Vector3.one;
            
            obj_.rectTransform.localPosition = new Vector2(0 + Interval * i, 0);

            StickS_.Add(obj_);
        }
    }

    void Update()
    {
        _fSpectrum();
    }

    void _fSpectrum()
    {
        float[] SpectRumData = AudioListener.GetSpectrumData(2048, 0, FFTWindow.Hamming);                               //스펙트럼 데이터 배열에 들리는 오디오를 스펙트럼 데이터에 대입
        for(int i = 0; i< StickS_.Count; i++)
        {
            Vector2 FirstScale = StickS_[i].transform.localScale;     //처음 막대기 크기
            FirstScale.y = 0.02f + SpectRumData[i] * 30;             //막대기 y스펙트럼에 맞춤
            StickS_[i].transform.localScale = Vector2.MoveTowards(StickS_[i].transform.localScale , FirstScale, 0.1f);//
        }
    }
}
