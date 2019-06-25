using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Uimng : MonoBehaviour
{
    public Stage stageMng;
    // Use this for initialization


    public void SceneChange(string Name)
    {
        SceneManager.LoadScene(Name);
    }

    public void StageCho()
    {
        stageMng.isSel = true;
    }
    public void steaglist(Button but)
    {
        if (but.gameObject.CompareTag("1stage"))
        {
            stageMng.stagenum[0] = true;
        }
        if (but.gameObject.CompareTag("2stage"))
        {
            stageMng.stagenum[1] = true;
        }
        if (but.gameObject.CompareTag("3stage"))
        {
            stageMng.stagenum[2] = true;

        }
        if (but.gameObject.CompareTag("4stage"))
        {
            stageMng.stagenum[3] = true;

        }
        if (but.gameObject.CompareTag("5stage"))
        {
            stageMng.stagenum[4] = true;
        }
    }
}
