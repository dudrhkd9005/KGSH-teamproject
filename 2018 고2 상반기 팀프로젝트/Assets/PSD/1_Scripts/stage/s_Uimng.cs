using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class s_Uimng : MonoBehaviour
{
    public SongList SongCtrl;
    public Image infScebn;
    public Image title_;
    public Image qwerqwer;
    public Animator Aasdfgh;
    public Image _1;
    public Image _2;
    public Image _3;

    public GameObject _Option;
    
    public void SceneChange(string Name)//씬전환
    {
        SceneManager.LoadScene(Name);
    }
    public void InfOut(Image img)
    {
        img.gameObject.SetActive(false);
        SongCtrl.Thm_infisBle = false;
    }


    public void Screen(GameObject obj)
    {
        if (obj.activeSelf)
        {
            obj.SetActive(false);
        }
        else
        {
            obj.SetActive(true);
        }
    }
    public void GameQuit()
    {
        Application.Quit();
    }

    public void Option_Of()
    {
        if(_Option.activeSelf == true)
        {
            iTween.ValueTo(this.gameObject, iTween.Hash(
                "from", 1,
                "to", 0,
                "time", 0.5f,
                "onUpdate", "Option_Off",
                "oncomplete", "Option_Active"
                ));
        }
        else
        {
            _Option.SetActive(true);
            iTween.ValueTo(this.gameObject,iTween.Hash(
                "from",0,
                "to",1,
                "time",0.5f,
                "onUpdate","Option_On"));

        }
    }
    void Option_Active()
    {
        _Option.SetActive(false);
    }
    void Option_Off(float val)
    {
        for (int i = 0; i < _Option.transform.childCount; i++)
        {
            _Option.transform.GetChild(i).GetComponent<Image>().color = new Vector4(255, 255, 255, val);
        }
    }
    void Option_On(float val)
    {
        for(int i= 0; i < _Option.transform.childCount;i++)
        {
            _Option.transform.GetChild(i).GetComponent<Image>().color = new Vector4(255, 255, 255, val);
        }
    }

 /////////////////////////////////////////////////////////////////////////////

    public void deswfrsghjk()
    {
        SongCtrl.Currentsong.rectTransform.localPosition = new Vector3(-605, 965, 0);
        //SongCtrl.SelThm.rectTransform.sizeDelta = new Vector2(550, 550);
        SongCtrl.NextSelThm = null;
        SongCtrl.SelThm = null;
        SongCtrl.StopSel = false;
        SongCtrl.SelThmIsble = false;
        SongCtrl.NextSelIsble = false;
        Aasdfgh.SetBool("ch", false);
        iTween.ValueTo(this.gameObject, iTween.Hash(
            "from", 1,
            "to", 0,
            "time", 0.5f,
            "onUpdate", "val_",
           "oncomplete", "qewrty"
         ));
        //iTween.ValueTo(this.gameObject, iTween.Hash(
        //    "from", 1,
        //    "to", 1,
        //    "time", 0.8f,
        //    "onUpdate", "BlroF",
        //     ));

    }
    void val_(float val)
    {
       
        title_.color = new Vector4(255, 255, 255, val);
        _1.color = new Vector4(255, 255, 255, val);
        _2.color = new Vector4(255, 255, 255, val);
        _3.color = new Vector4(255, 255, 255, val);
        for (int i = 1; i <= 3; i++)
        {
            title_.transform.GetChild(i).GetComponent<Image>().color = new Vector4(255, 255, 255, val);
        }
        qwerqwer.color = new Vector4(255, 255, 255, val);
        for (int i = 0; i <= 3; i++)
        {
            qwerqwer.transform.GetChild(i).GetComponent<Image>().color = new Vector4(255, 255, 255, val);
        }
    }
    void qewrty()
    {
        infScebn.gameObject.SetActive(false);
    }
    void BlroF(float val)
    {
    //    infScebn.material.SetFloat("_Radius", val);
    }
}

