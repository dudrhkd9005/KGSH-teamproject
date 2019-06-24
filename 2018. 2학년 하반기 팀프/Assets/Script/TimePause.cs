using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePause : MonoBehaviour {

    private bool isTimePause;
    public bool IsTimePause
    {
        set
        {
            isTimePause = value;
        }
        get
        {
            return isTimePause;
        }
    }
    private static TimePause instance;
    public static TimePause Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<TimePause>();
            return instance;
        }

    }

    public float IsMove() { return (isTimePause ? 0 : 1); }
    
}
