using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {
    public GameObject screen;
    public Slider slider;
    public TMPro.TextMeshProUGUI text;

    public void LoadScene(string name)
    {
        StartCoroutine(LoadAsynchronously(name));
    }

    IEnumerator LoadAsynchronously(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);

        screen.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress);

            slider.value = progress;
            text.text = (int)(progress * 100f) + "%";

            yield return null;
        }
    }
}
