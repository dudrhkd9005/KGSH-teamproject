using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageUIMng : MonoBehaviour
{
    public ScrollRect scroll;
    //public Animator anim;
    //public LoadingScreen loading;
    //public void SceneChange(string name)
    //{
    //    if (!scroll.inertia)
    //    {
    //        loading.LoadScene(name);
    //    }
    //}

    //public void Window(Image uiobj)
    //{
    //    if (uiobj.gameObject.activeSelf == true)
    //    {
    //        anim.SetBool("optionong", false);
    //    }
    //    else
    //    {
    //        anim.SetBool("optionong", true);
    //    }
    //}
    public void _Window(Image uiobj)
    {
        if (uiobj.gameObject.activeSelf == true)
        {
            uiobj.gameObject.SetActive(false);
        }
        else
        {
            uiobj.gameObject.SetActive(true);
        }
    }
}
