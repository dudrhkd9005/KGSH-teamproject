using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageMng : MonoBehaviour
{
    public bool IsSel;//스테이지 선택체크
    public List<Image> Song;//
    int SongThumbnail_Pos;//포지션 계산 변수
    int SongThumbnailintervalY;//포지션 간격 변수
    int SongThumbnailintervalX;
    //public Sprite[] SongThumbnail;//곡의 썸네일
    // Use this for initialization
    void Start()
    {
        IsSel = false;
        SongThumbnail_Pos = 2;
        SongThumbnailintervalY = -20;
        SongThumbnailintervalX = 10;
        for (int i=1;i< Song.Count;i++)
        {
            Song[i].rectTransform.localPosition = new Vector3((Song[0].rectTransform.localPosition.x  * SongThumbnail_Pos) + SongThumbnailintervalX,
                                                              (Song[0].rectTransform.localPosition.y * SongThumbnail_Pos) + SongThumbnailintervalY, 0);
            
            SongThumbnail_Pos++;
            SongThumbnailintervalY -= 20;
            SongThumbnailintervalX += 10;
            if(i== Song.Count-1)
            {
                for(int j=0;j<Song.Count;j++)
                {
                    Song[j].gameObject.SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        StageSel_();
    }
    void StageSel_() //스테이지 선택
    {
        if(IsSel == true)
        {
            for(int i= 0; i<Song.Count;i++)
            {
                Song[i].gameObject.SetActive(true);
                Alpha_on(Song[i]);
            }
        }
        else
        {
            for (int i = 0; i < Song.Count; i++)
            {

                Alpha_off(Song[i]);
                Song[i].gameObject.SetActive(false);
            }
        }
    }

    void Alpha_on(Image img,float A=0)
    {
        Color Temp = img.color;
        Temp.a = 1.0f;
        img.color = Temp;
        //img.color = new Color(img.color.r, img.color.g, img.color.b, A);
        //if(A<=255)
        //{
        //    A += Time.deltaTime;
        //}
    }
    void Alpha_off(Image img, float A = 0)
    {
        Color Temp = img.color;
        Temp.a = 0.0f;
        img.color = Temp;
        //img.color = new Color(img.color.r, img.color.g, img.color.b, A);
        //if(A<=255)
        //{
        //    A += Time.deltaTime;
        //}
    }
    

    ////////////////////버튼 클릭 체크
    public void StageBut(Button but)
    {
        if(IsSel == false)
        {
            IsSel = true;
        }
        else
        {
            IsSel = false;
        }
    }
}
