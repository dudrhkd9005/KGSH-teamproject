﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public enum NoteKind
    {
        Short,
        Swipe,
        Long,
        SubLong
    }

    public NoteKind noteKind;
    public float position;
    public int num;
    public float time;
    public bool off;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
