using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scrollbarctrl : MonoBehaviour {

    public RectTransform contentrect;
    float Xpos;
    public Slider thisscroll;
	// Use this for initialization
	void Start () {
        Xpos = 6447.079f;
        thisscroll.maxValue = Xpos;

    }
    private void Update()
    {
       thisscroll.value = -contentrect.transform.localPosition.x ;
      //  Debug.Log(thisscroll.value);
     //   Debug.Log(-contentrect.transform.localPosition.x);
    }
    // Update is called once per frame

}
