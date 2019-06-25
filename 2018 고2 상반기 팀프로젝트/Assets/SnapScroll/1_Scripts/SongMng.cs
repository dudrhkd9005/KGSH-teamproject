using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongMng : MonoBehaviour {
    public SongBuffer Songbf;
    public Transform SongFrom;

    private List<Song> S_Inf;
	// Use this for initialization
	void Start () {
        S_Inf = new List<Song>();

        int Cont_Song = SongFrom.childCount;


        for (int i = 0; i < Cont_Song; i++)
        {
            var slot = SongFrom.GetChild(i).GetComponent<Song>();

            if(i< Songbf.songInf.Count)
            {
                //Debug.Log(Songbf.songInf[i].SongName.name);
                slot.Setting(Songbf.songInf[i]);
            }
        }
    }
	

}
