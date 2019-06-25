using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Song : MonoBehaviour
{[HideInInspector]
    public SongInfList Inf;

    public Image ThisThm;
    public void Setting(SongInfList _Inf)
    {
        this.Inf = _Inf;

        if(Inf == null)
        {
            gameObject.name = "NotSong";
        }
        else
        {
            gameObject.name = Inf.Name;
            ThisThm.sprite = Inf.Song_Thm;
        }
    }
}
