using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelMng : MonoBehaviour
{
    public SnapScrolling _scrolling;
    public Animator UIanim;
    public void PlaySTage()
    {
        UIanim.gameObject.SetActive(true);
        UIanim.SetBool("InfFaid", true);
        _scrolling.StartSelSOng =true;
    }
}
