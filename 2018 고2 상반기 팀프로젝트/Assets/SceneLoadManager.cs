using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadManager : MonoBehaviour
{
    Animation ani;
    public AnimationClip faidIn;
    public AnimationClip faidOut;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animation>();
        ani.clip = faidIn;
        ani.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string _name)
    {
        StartCoroutine(Delay(_name));
    }

    IEnumerator Delay(string _name)
    {
        ani.clip = faidOut;
        ani.Play();
        yield return new WaitForSeconds(ani.clip.length);
        UnityEngine.SceneManagement.SceneManager.LoadScene(_name);
    }
}
