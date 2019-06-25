using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboUI : MonoBehaviour
{
    public SpriteNumber number;
    new Animation animation;
    int combo = 0;
    int maxCombo;
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
        combo = 0;
        number.transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpCombo()
    {
        animation.Stop();
        animation.Play();
        combo++;
        if (combo > maxCombo)
            maxCombo = combo;
        number.value = combo;
        number.transform.parent.gameObject.SetActive(true);
    }

    public void breakCombo()
    {
        combo = 0;
        number.transform.parent.gameObject.SetActive(false);
    }

    public int GetCombo()
    {
        return combo;
    }

    public int GetMaxCombo()
    {
        return maxCombo;
    }
}
