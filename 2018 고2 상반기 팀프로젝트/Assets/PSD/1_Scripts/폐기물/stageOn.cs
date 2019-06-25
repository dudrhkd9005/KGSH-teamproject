using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class stageOn : MonoBehaviour
{
    public Image slot;//슬롯
    bool Chek; //선택됬는지
    int SongNum; // 곡넘버

    public int Countnum; // 곡 수



    List<Image> Song = new List<Image>();


    float SlotXpos;
    float SlotYpos;
    int count;
    bool Yposco;
    // Use this for initialization
    void Start()
    {
        count = 0;
        Yposco = false;
        /////
        ListAdd();
        for (int i = 1; i < Song.Count; i++)
        {
            
            if (i >= 1)
            {
                count++;
                if (count == 2 && Yposco == false)
                {
                    SlotXpos += 0.1f;
                    SlotYpos = 0.075f;
                    count = 0;
                    Yposco = true;

                }
                if (count == 2 && Yposco == true)
                {
                    SlotXpos += 0.1f;
                    SlotYpos = 0.0f;
                    count = 0;
                    Yposco = false;

                }

            }
            //if(Holcek == true )
            //{
            //    SlotXpos += 0.1f;
            //    SlotYpos = 0;
            //    Holcek = false;
            //}

            if (i % 2 == 0 && i != 0)
            {
                Song[i].rectTransform.localPosition = new Vector3((Song[0].rectTransform.localPosition.x + SlotXpos), Song[0].rectTransform.localPosition.y + SlotYpos, 0);
            }
            else
            {
                Song[i].rectTransform.localPosition = new Vector3((Song[0].rectTransform.localPosition.x + SlotXpos), Song[0].rectTransform.localPosition.y + (SlotYpos - 0.15f), 0);
            }

            if(i==Song.Count-1)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ListAdd()
    {
        for (int i = 0; i < Countnum; i++)
        {
            Image Solt_obj = Instantiate(slot) as Image;
            Solt_obj.transform.parent = this.gameObject.transform;
            Solt_obj.rectTransform.localPosition = Vector3.zero;
            Song.Add(Solt_obj);
        }
    }
}
