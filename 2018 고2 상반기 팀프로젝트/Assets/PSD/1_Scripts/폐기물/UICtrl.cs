using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UICtrl : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    

    public STAGESLESCRIPTS stagselmng;

    public void Option_but(Image img)
    {
        if (img.gameObject.activeSelf == true)
        {
            img.gameObject.SetActive(false);
        }
        else
        {
            img.gameObject.SetActive(true);
        }
    }

    public void stageBack(Button but)
    {
        if(stagselmng.isSelStageMod)    
        {
            stagselmng.Revert=true;
            stagselmng.MoveSpeedacc = 1;
          
            // stagselmng.Revert = true;
        }
    }

    public void SceneChang(string name)
    {
         
    }
}
