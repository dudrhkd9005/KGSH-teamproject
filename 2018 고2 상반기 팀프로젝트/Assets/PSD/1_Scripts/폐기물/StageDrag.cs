using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageDrag : MonoBehaviour
{
    public float Speed;

    private float _halfHeight;
    // Use this for initialization
    void Start()
    {
        _halfHeight = Screen.height * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {   
            float _deltaPosY = Input.GetTouch(0).position.y - _halfHeight;
            float _Ypos = _deltaPosY - transform.position.y;
                Debug.Log(_Ypos);
        }

    }
}
