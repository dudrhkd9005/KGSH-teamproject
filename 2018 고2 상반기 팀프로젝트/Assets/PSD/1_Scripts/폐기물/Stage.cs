using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage : MonoBehaviour
{


     
    public List<Image> StageThm;  //스테이지 버튼 리스트
    public RectTransform backgroundrect; // 배ㅑ경
    public bool[] stagenum;
    float delayTime; //이펙트 딜레이 시간

    public bool isSel; //스테이지 버튼 클릭 체크
    float asdf;  //x background
    float asdfg;//y background
    // Use this for initialization
    void Start()
    {
        asdf = 0;
        asdfg = 0;
        delayTime = 0;
        isSel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSel)
        {
            stageSelEf();

            isSel = false;

        }
    }

    void stageSelEf()
    {

        for (int i = 0; i < StageThm.Count; i++)
        {
            if (i == 0 || i % 2 == 0)
            {
                iTween.MoveBy(StageThm[i].gameObject, iTween.Hash(
                    "x", -3.5f,
                    "y", 14.5,
                    "time", 2.5f,
                    "delay", delayTime,
                    "islocal", true

                    ));

            }
            else
            {
                iTween.MoveBy(StageThm[i].gameObject, iTween.Hash(
                    "x", +3.9,
                    "y", -14.5,
                    "time", 2.5f,
                    "delay", delayTime,
                    "islocal", true

                    ));
            }



            delayTime += 0.15f;
        }

        iTween.ValueTo(this.gameObject, iTween.Hash(
                        "from", 0,
                        "to", 9,
                        "time", 1.5f,
                        "delay", delayTime + 0.5f,
                        "onUpdate", "Scale_X"
            ));
   
    }
    void Scale_X(float value_)
    {
        asdf = value_ + 1;
        asdfg = value_ * 2;
        backgroundrect.sizeDelta = new Vector2(asdfg, asdf);
        delayTime = 0;
    }




}

