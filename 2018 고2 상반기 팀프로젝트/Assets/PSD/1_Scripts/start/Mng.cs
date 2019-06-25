using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mng : MonoBehaviour
{
    public Image Option_;

    public void GameQuit()
    {
        Application.Quit();
    }

    public void SceneChange(string _name)
    {
        SceneManager.LoadScene(_name);
    }

    public void ScreenOnf(GameObject obj)
    {
        if (obj.activeSelf == true)
        {
            iTween.Stop(this.gameObject);

            iTween.ValueTo(this.gameObject, iTween.Hash(
                 "from", Option_.rectTransform.sizeDelta.x,
                 "to", 0,
                 "onUpdate", "Val_1",
                 "time", 0.3f));
            iTween.ValueTo(this.gameObject, iTween.Hash(
                "from", 1,
                "to", 0,
                "time", 0.3f,
                "onUpdate", "Val_2",
                "oncomplete", "eft"));
        }
        else
        {
            obj.SetActive(true);
            iTween.ValueTo(this.gameObject, iTween.Hash(
               "from", 0,
               "to", 960,
               "onUpdate", "Val_1",
               "time", 0.3f));
            iTween.ValueTo(this.gameObject, iTween.Hash(
                "from", 0,
                "to", 1,
                "time", 0.3f,
                "onUpdate", "Val_2"));
        }
    }
    void Val_1(float val)
    {
        Option_.rectTransform.sizeDelta = new Vector2(val, val);
    }
    void Val_2(float val)
    {
        Option_.color = new Vector4(255, 255, 255, val);
    }
    void eft()
    {
        Option_.transform.parent.gameObject.SetActive(false);
    }
}
