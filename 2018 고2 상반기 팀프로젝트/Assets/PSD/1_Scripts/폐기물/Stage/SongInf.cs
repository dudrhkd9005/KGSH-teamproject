using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SongInf : MonoBehaviour
{
    public Sprite SongThumbnail; //썸네일
    public string Name;          //곡이름
    public float Time;           //시간
    public int NoteNum;          //노트 수

    Image Thisimg;

    public string Scene_SongName;
    private void Start()
    {
        Thisimg = GetComponent<Image>();
        Thisimg.sprite = SongThumbnail;
    }
}
