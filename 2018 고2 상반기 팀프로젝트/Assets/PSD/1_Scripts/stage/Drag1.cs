using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag1 : MonoBehaviour
{
    bool WorkTouch;


   // public
    public GameObject targetObj;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TouchDrag();    

    }

    void TouchDrag()
    {

        Touch FirstTouch;
        if (Input.touchCount > 0)
        {
            FirstTouch = Input.GetTouch(0);
            if(FirstTouch.phase == TouchPhase.Began)
            {
                WorkTouch = true;
            }
            else if(FirstTouch.phase == TouchPhase.Ended)
            {
                WorkTouch = false;
            }


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////Fuck/////////////////////////////////////////////////////////////////////////////////////////////////////////Fcuk
            if (WorkTouch)
            {
                Vector2 FirstPos = FirstTouch.position;
                float Description = FirstTouch.deltaPosition.x;
                if (Description != 0)
                {
                    targetObj.transform.position += new Vector3(Description,0);
                }
            }
        }

        
    }
}
